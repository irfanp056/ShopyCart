// Models/CustomerBasket.cs
namespace AspireApp2.Shared1.Models;

public class CustomerBasket
{
    public string BuyerId { get; set; } = string.Empty;
    public List<BasketItem> Items { get; set; } = [];
}
