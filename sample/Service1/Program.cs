using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using FxMap.EntityFrameworkCore.Extensions;
using FxMap.Extensions;
using FxMap.HotChocolate.Extensions;
using FxMap.MongoDb.Extensions;
using FxMap.Supervision;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;
using Serilog;
using Shared.Transports;
using Service1;
using Service1.Contexts;
using Service1.Contract;
using Service1.GraphQls;
using Service1.Models;
using Shared.RunSqlMigration;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

// Configure OpenTelemetry for distributed tracing and metrics
builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
        .AddService("Service1", serviceVersion: "1.0.0")
        .AddAttributes(new Dictionary<string, object>
        {
            ["environment"] = builder.Environment.EnvironmentName,
            ["host.name"] = Environment.MachineName
        }))
    .WithTracing(tracing => tracing
        .AddSource("FxMap") // Subscribe to FxMap traces
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddOtlpExporter(options => options.Endpoint = new Uri("http://localhost:4317")))
    .WithMetrics(metrics => metrics
        .AddMeter("FxMap") // Subscribe to FxMap metrics
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation());

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var client = new MongoClient("mongodb://localhost:27017");
var database = client.GetDatabase("Service1MongoDb");
var memberSocialCollection = database.GetCollection<MemberSocial>("MemberSocials");

var registerBuilder = builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<MembersType>();

builder.Services.AddFxMap(cfg =>
    {
        cfg.AddEntitiesFromAssemblyContaining<IAssemblyMarker>();
        cfg.AddProfilesFromAssemblyContaining<IService1ContractAssembly>();

        // Grpc, Nats, RabbitMq, Kafka, Sqs or ServiceBus: see the launch profiles and appsettings.{Environment}.json
        cfg.AddConfiguredTransport(builder.Configuration);
        cfg.ConfigureSupervisor(opts =>
        {
            opts.Strategy = SupervisionStrategy.OneForOne;
            opts.MaxRestarts = 5;
            opts.EnableCircuitBreaker = true;
            opts.CircuitBreakerThreshold = 3;
        });
        cfg.ThrowIfException();
    })
    .AddEntityFrameworkCore(cfg => { cfg.AddDbContexts(typeof(Service1Context), typeof(OtherService1Context)); })
    .AddMongoDb(cfg => cfg.AddCollection(memberSocialCollection))
    .AddHotChocolate(cfg => cfg.AddRequestExecutorBuilder(registerBuilder));

#region Setting Database and Seeding data

builder.Services.AddDbContextPool<Service1Context>(options =>
{
    options.UseNpgsql("Host=localhost;Username=postgres;Password=Abcd@2021;Database=FxMapService1", b =>
    {
        b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
    });
}, 128);

builder.Services.AddDbContextPool<OtherService1Context>(options =>
{
    options.UseNpgsql("Host=localhost;Username=postgres;Password=Abcd@2021;Database=FxMapOtherService1", b =>
    {
        b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
        b.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
    });
}, 128);

#endregion

builder.Services.AddControllers();

var app = builder.Build();

// Creates the tables and seeds the PostgreSQL data (see ContextMigrations/, OtherContextMigrations/ and
// Data/Service1SeedData.cs)
await MigrationDatabase.MigrationDatabaseAsync<Service1Context>(app);
await MigrationDatabase.MigrationDatabaseAsync<OtherService1Context>(app);

// MongoDB has no migrations, so MemberSocial is still seeded in code
await Service1.Data.Service1MongoSeeder.SeedMemberSocialAsync(memberSocialCollection);

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGraphQL();

app.Run();