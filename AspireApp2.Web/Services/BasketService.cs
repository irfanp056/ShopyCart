using AspireApp2.Web.Models;

namespace AspireApp2.Web.Services;

public class BasketService(HttpClient httpClient)
{
    public async Task<CustomerBasket?> GetBasketAsync(string userId)
    {
        try
        {
            return await httpClient.GetFromJsonAsync<CustomerBasket>($"/api/basket/{userId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching basket: {ex.Message}");
            return null;
        }
    }

    public async Task<bool> UpdateBasketAsync(CustomerBasket basket)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("/api/basket", basket);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating basket: {ex.Message}");
            return false;
        }
    }
}
