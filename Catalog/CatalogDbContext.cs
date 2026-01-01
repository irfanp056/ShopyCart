namespace Catalog

{
    using Microsoft.EntityFrameworkCore;
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogItem> CatalogItems => Set<CatalogItem>();
    }

    public class CatalogItem
    {
      public int Id { get; set; }
      public string Name { get; set; } = string.Empty;

      public string Description { get; set; } = string.Empty;
        public float Price { get; set; }

      public string PictureFileName { get; set; } = string.Empty;
    }
}
