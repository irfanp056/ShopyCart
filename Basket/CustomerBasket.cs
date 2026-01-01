namespace Basket
{

    public class CustomerBasket
    {
        public string Id { get; set; } = string.Empty;

        public string BuyerId { get; set; } = string.Empty;
        public List<BasketItem> Items { get; set; } = new();

    }

    public class BasketItem 
    { 
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
    }

}
