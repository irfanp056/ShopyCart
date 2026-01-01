using Blazor.Components;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
namespace Blazor;


public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Add HTTP clients for microservices
        builder.Services.AddHttpClient("CatalogAPI", client =>
        {
            client.BaseAddress = new Uri("https+http://catalog-api");
        });

        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("CatalogAPI"));

        //builder.Services.AddHttpClient<CatalogService>(client =>
        //{
        //    client.BaseAddress = new Uri("https+http://catalog-api");
        //});

        //builder.Services.AddHttpClient<BasketService>(client =>
        //{
        //    client.BaseAddress = new Uri("https+http://basket-api");
        //});

        // Use named clients instead(NO CLASSES REQUIRED)
        //builder.Services.AddHttpClient("CatalogAPI", client =>
        //{
        //    client.BaseAddress = new Uri("https+http://catalog-api");
        //});

        //builder.Services.AddHttpClient("BasketAPI", client =>
        //{
        //    client.BaseAddress = new Uri("https+http://basket-api");
        //});

        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.MapStaticAssets();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}
