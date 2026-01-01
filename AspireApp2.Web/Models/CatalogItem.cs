namespace AspireApp2.Web.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string PictureFileName { get; set; } = string.Empty;
    }
}
