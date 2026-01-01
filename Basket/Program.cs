
using StackExchange.Redis;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Basket;

public class Program
{

    public record BasketItem(int ProductId, String ProductName, float Price, int Quantiry);

    public record CustomerBasket(string BuyerId, List<BasketItem> Items);
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        


    builder.AddServiceDefaults();

            
    // Add Redis for basket storage

    builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
        {
            var configuration = provider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("basketcache");
            return ConnectionMultiplexer.Connect(connectionString);
        });

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.MapDefaultEndpoints();

        //Basket endpoints
        app.MapGet("/api/basket/{userId}", async (string userId, IConnectionMultiplexer redis) =>
        {
            var db = redis.GetDatabase();
            var json = await db.StringGetAsync(userId);
            if (json.IsNullOrEmpty)
                return Results.NotFound();
            var jsonString = (string)json;
            var basket = JsonSerializer.Deserialize<CustomerBasket>(jsonString!);
            return Results.Ok(basket);
        });

        app.MapPost("/api/basket", async (CustomerBasket basket, IConnectionMultiplexer redis) =>
        {
            var db = redis.GetDatabase();
            var json = JsonSerializer.Serialize(basket);
            await db.StringSetAsync(basket.BuyerId, json);
            return Results.Ok(basket);


        }
            );

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();

        
    }
}
