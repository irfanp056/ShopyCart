var builder = DistributedApplication.CreateBuilder(args);

// Add database
var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin()
    .AddDatabase("catalogdb");

var redis = builder.AddRedis("basketcatcache");

// Add services
var catalogApi = builder.AddProject<Projects.Catalog>("catalog-api")
    .WithReference(postgres);

var basketApi = builder.AddProject<Projects.Basket>("basket-api")
    .WithReference(redis);

// Add frontend
var webApp = builder.AddProject < Projects.AspireApp2_Web>("webapp")
    .WithReference(catalogApi)
    .WithReference(basketApi);


var apiService = builder.AddProject<Projects.AspireApp2_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.AspireApp2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddProject<Projects.Catalog>("catalog");

builder.AddProject<Projects.Basket>("basket");

builder.AddProject<Projects.Blazor>("blazor");

builder.Build().Run();
