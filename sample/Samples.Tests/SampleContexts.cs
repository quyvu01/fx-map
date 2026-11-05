using Microsoft.EntityFrameworkCore;
using Service1.Contexts;
using Service2.Contexts;
using Service3Api.Contexts;

namespace Samples.Tests;

/// <summary>The four contexts of the sample services, on PostgreSQL as the services run them.</summary>
public static class SampleContexts
{
    /// <summary>A connection string for the model only: nothing connects to it.</summary>
    public const string NoDatabase = "Host=localhost;Database=unused";

    public static readonly string[] Names = ["Service1", "OtherService1", "Service2", "Service3"];

    public static DbContext Create(string name, string connectionString = NoDatabase) => name switch
    {
        "Service1" => new Service1Context(Options<Service1Context>(connectionString)),
        "OtherService1" => new OtherService1Context(Options<OtherService1Context>(connectionString)),
        "Service2" => new Service2Context(Options<Service2Context>(connectionString)),
        "Service3" => new Service3Context(Options<Service3Context>(connectionString)),
        _ => throw new ArgumentOutOfRangeException(nameof(name), name, null)
    };

    private static DbContextOptions<T> Options<T>(string connectionString) where T : DbContext =>
        new DbContextOptionsBuilder<T>().UseNpgsql(connectionString).Options;
}
