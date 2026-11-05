using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Service1.Data;
using Service1.Models;
using Service2.Data;
using Service2.Models;
using Service3Api.Data;
using Service3Api.Models;
using Shouldly;
using Xunit;

namespace Samples.Tests.UnitTests;

/// <summary>
/// The seed data is in the models (<c>HasData</c>), and the migrations are up to date with it: a change to the seed
/// data without a new migration fails here, not at runtime.
/// </summary>
public class SeedModelTests
{
    public static IEnumerable<object[]> Contexts => SampleContexts.Names.Select(n => new object[] { n });

    [Theory]
    [MemberData(nameof(Contexts))]
    public void The_migrations_match_the_model_and_its_seed_data(string context)
    {
        using var db = SampleContexts.Create(context);
        db.Database.HasPendingModelChanges().ShouldBeFalse();
    }

    [Theory]
    [MemberData(nameof(Contexts))]
    public void The_last_migration_is_the_seed_data(string context)
    {
        using var db = SampleContexts.Create(context);
        var migrations = db.Database.GetMigrations().ToList();
        migrations.Count.ShouldBe(2);
        migrations[^1].ShouldEndWith("_SeedData");
    }

    [Fact]
    public void Service3_model_seeds_the_countries_and_provinces()
    {
        using var db = SampleContexts.Create("Service3");
        SeedCount<Country>(db).ShouldBe(Service3SeedData.Countries.Count);
        SeedCount<Province>(db).ShouldBe(Service3SeedData.Provinces.Count);
    }

    [Fact]
    public void Service2_model_seeds_the_users()
    {
        using var db = SampleContexts.Create("Service2");
        SeedCount<User>(db).ShouldBe(Service2SeedData.Users.Count);
    }

    [Fact]
    public void Service1_models_seed_the_member_data()
    {
        using var db = SampleContexts.Create("Service1");
        SeedCount<MemberAdditionalData>(db).ShouldBe(Service1SeedData.MemberAdditionalDatas.Count);
        using var other = SampleContexts.Create("OtherService1");
        SeedCount<MemberAddress>(other).ShouldBe(Service1SeedData.MemberAddresses.Count);
    }

    // The runtime model leaves the seed data out, the design-time model (the one migrations are made from) has it
    private static int SeedCount<T>(DbContext db) =>
        db.GetService<IDesignTimeModel>().Model.FindEntityType(typeof(T))!.GetSeedData().Count();
}
