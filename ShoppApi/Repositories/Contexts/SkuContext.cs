using Microsoft.EntityFrameworkCore;

namespace ShoppApi.Model
{
    public class SkuContext : DbContext
    {
        public DbSet<Sku> Products { get; set; }
        public SkuContext(DbContextOptions<SkuContext> options) : base(options)
        { }
    }
}