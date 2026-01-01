using AspireApp2.Web.Components;
using AspireApp2.Web.Services;  // ← Add this

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register the services
builder.Services.AddHttpClient<CatalogService>(client =>
{
    client.BaseAddress = new Uri("https+http://catalog-api");
});

builder.Services.AddHttpClient<BasketService>(client =>
{
    client.BaseAddress = new Uri("https+http://basket-api");
});

var app = builder.Build();

app.MapDefaultEndpoints();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();