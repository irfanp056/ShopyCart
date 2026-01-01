namespace AspireApp2.Web.Models
{
    public record CustomerBasket(string BuyerId, List<BasketItem> Items);

    public record BasketItem(int ProductId, string ProductName, decimal Price, int Quantity);
}
