using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Service1.Contexts;
using Service1.Data;
using Service1.Models;
using Service2.Contexts;
using Service2.Data;
using Service2.Models;
using Service3Api.Contexts;
using Service3Api.Data;
using Service3Api.Models;
using Shared.RunSqlMigration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shouldly;
using Xunit;

namespace Samples.Tests.IntegrationTests;

/// <summary>The migrations of the sample services against a real PostgreSQL: they create the tables and the seed data.</summary>
[Collection(PostgresCollection.Name)]
public class SeedMigrationTests(PostgresFixture postgres)
{
    [Fact]
    public async Task Service3_migrations_seed_the_countries_and_provinces()
    {
        await using var db = (Service3Context)SampleContexts.Create("Service3", postgres.NewDatabase());
        await db.Database.MigrateAsync();

        (await db.Countries.OrderBy(c => c.Id).Select(c => c.Id + "|" + c.Name).ToListAsync())
            .ShouldBe(Service3SeedData.Countries.OrderBy(c => c.Id).Select(c => c.Id + "|" + c.Name));
        (await db.Provinces.OrderBy(p => p.Id).Select(p => p.Id + "|" + p.Name + "|" + p.CountryId).ToListAsync())
            .ShouldBe(Service3SeedData.Provinces.OrderBy(p => p.Id).Select(p => p.Id + "|" + p.Name + "|" + p.CountryId));
        (await db.Provinces.Where(p => p.Country.Name == "Vietnam").CountAsync()).ShouldBe(3);
    }

    [Fact]
    public async Task Service2_migrations_seed_the_users()
    {
        await using var db = (Service2Context)SampleContexts.Create("Service2", postgres.NewDatabase());
        await db.Database.MigrateAsync();

        (await db.Users.OrderBy(u => u.Id).Select(u => u.Id + "|" + u.Name + "|" + u.Email + "|" + u.ProvinceId)
                .ToListAsync())
            .ShouldBe(Service2SeedData.Users.OrderBy(u => u.Id)
                .Select(u => u.Id + "|" + u.Name + "|" + u.Email + "|" + u.ProvinceId));
        var john = await db.Users.SingleAsync(u => u.Id == "user-001");
        john.CreatedTime.ShouldBe(Service2SeedData.CreatedTime);
    }

    [Fact]
    public async Task Service1_migrations_seed_the_member_data()
    {
        await using var db = (Service1Context)SampleContexts.Create("Service1", postgres.NewDatabase());
        await db.Database.MigrateAsync();
        (await db.MemberAdditionalDatas.OrderBy(m => m.Id).Select(m => m.Id + "|" + m.Name).ToListAsync())
            .ShouldBe(Service1SeedData.MemberAdditionalDatas.OrderBy(m => m.Id).Select(m => m.Id + "|" + m.Name));

        await using var other = (OtherService1Context)SampleContexts.Create("OtherService1", postgres.NewDatabase());
        await other.Database.MigrateAsync();
        (await other.MemberAddresses.OrderBy(a => a.Id)
                .Select(a => a.Id + "|" + a.ProvinceId + "|" + a.Street + "|" + a.City + "|" + a.ZipCode).ToListAsync())
            .ShouldBe(Service1SeedData.MemberAddresses.OrderBy(a => a.Id)
                .Select(a => a.Id + "|" + a.ProvinceId + "|" + a.Street + "|" + a.City + "|" + a.ZipCode));
    }

    /// <summary>
    /// A database that the old code seeding filled (the initial migration, then the rows written when the service
    /// started) takes the seed migration: the seeded rows are replaced, the others are kept.
    /// </summary>
    [Fact]
    public async Task A_database_filled_by_the_old_seeding_takes_the_seed_migration()
    {
        await using var db = (Service2Context)SampleContexts.Create("Service2", postgres.NewDatabase());
        await MigrateToInitialAsync(db);
        db.Users.Add(new User
        {
            Id = "user-001", Name = "John Smith", Email = "john.smith@email.com",
            ProvinceId = "01962f9a-f7f8-7f61-941c-6a086fe96cd2", CreatedTime = DateTime.UtcNow
        });
        db.Users.Add(new User { Id = "someone-else", Name = "Kept", CreatedTime = DateTime.UtcNow });
        await db.SaveChangesAsync();
        db.ChangeTracker.Clear();

        await db.Database.MigrateAsync();

        (await db.Users.CountAsync()).ShouldBe(Service2SeedData.Users.Count + 1);
        (await db.Users.SingleAsync(u => u.Id == "user-001")).CreatedTime.ShouldBe(Service2SeedData.CreatedTime);
        (await db.Users.SingleAsync(u => u.Id == "someone-else")).Name.ShouldBe("Kept");
    }

    [Fact]
    public async Task A_database_filled_by_the_old_seeding_of_service3_takes_the_seed_migration()
    {
        await using var db = (Service3Context)SampleContexts.Create("Service3", postgres.NewDatabase());
        await MigrateToInitialAsync(db);
        db.Countries.Add(new Country
        {
            Id = "VN", Name = "Vietnam",
            Provinces = [new Province { Id = Guid.Parse("01962f9a-f7f8-7e3f-5a4b-234567abcdef"), Name = "Hanoi" }]
        });
        await db.SaveChangesAsync();
        db.ChangeTracker.Clear();

        await db.Database.MigrateAsync();

        (await db.Countries.CountAsync()).ShouldBe(Service3SeedData.Countries.Count);
        (await db.Provinces.CountAsync()).ShouldBe(Service3SeedData.Provinces.Count);
    }

    [Fact]
    public async Task Reverting_the_seed_migration_removes_the_seed_data()
    {
        await using var db = (Service3Context)SampleContexts.Create("Service3", postgres.NewDatabase());
        await db.Database.MigrateAsync();

        await MigrateToInitialAsync(db);

        (await db.Countries.CountAsync()).ShouldBe(0);
        (await db.Provinces.CountAsync()).ShouldBe(0);
    }

    /// <summary>What the services run when they start (<see cref="MigrationDatabase"/>), twice: the second run does nothing.</summary>
    [Fact]
    public async Task The_services_startup_migration_seeds_once()
    {
        var connectionString = postgres.NewDatabase();
        var builder = Host.CreateApplicationBuilder();
        builder.Services.AddDbContext<Service2Context>(o => o.UseNpgsql(connectionString));
        using var host = builder.Build();

        await MigrationDatabase.MigrationDatabaseAsync<Service2Context>(host);
        await MigrationDatabase.MigrationDatabaseAsync<Service2Context>(host);

        using var scope = host.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<Service2Context>();
        (await db.Users.CountAsync()).ShouldBe(Service2SeedData.Users.Count);
        (await db.Database.GetPendingMigrationsAsync()).ShouldBeEmpty();
    }

    private static Task MigrateToInitialAsync(DbContext db) =>
        db.GetService<IMigrator>().MigrateAsync(db.Database.GetMigrations().First());
}
