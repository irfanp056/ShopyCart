// Models/CustomerBasket.cs
namespace AspireApp2.Shared.Models;

public class CustomerBasket
{
    public string BuyerId { get; set; } = string.Empty;
    public List<BasketItem> Items { get; set; } = [];
}
