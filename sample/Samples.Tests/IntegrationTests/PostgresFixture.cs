using Npgsql;
using Testcontainers.PostgreSql;
using Xunit;

namespace Samples.Tests.IntegrationTests;

/// <summary>A real PostgreSQL in a container (Testcontainers), with a new database for each test.</summary>
public sealed class PostgresFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _container = new PostgreSqlBuilder().WithImage("postgres:17").Build();

    public Task InitializeAsync() => _container.StartAsync();

    public Task DisposeAsync() => _container.DisposeAsync().AsTask();

    public string NewDatabase() => new NpgsqlConnectionStringBuilder(_container.GetConnectionString())
    {
        // EF Core creates it on the first migration
        Database = $"samples_{Guid.NewGuid():N}"
    }.ConnectionString;
}

[CollectionDefinition(Name)]
public sealed class PostgresCollection : ICollectionFixture<PostgresFixture>
{
    public const string Name = "Postgres";
}
