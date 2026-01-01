using AspireApp2.Web.Models;

namespace AspireApp2.Web.Services;

public class CatalogService(HttpClient httpClient)
{
    public async Task<List<CatalogItem>> GetCatalogItemsAsync()
    {
        try
        {
            return await httpClient.GetFromJsonAsync<List<CatalogItem>>("/api/catalog/items")
                ?? new List<CatalogItem>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching catalog items: {ex.Message}");
            return new List<CatalogItem>();
        }
    }
}
