
using Microsoft.EntityFrameworkCore;

namespace ShoppApi.Model
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {}
    }
}
