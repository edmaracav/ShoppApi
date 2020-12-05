using Microsoft.EntityFrameworkCore;
using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Repositories.Contexts
{
    public class DatabaseContext : DbContext
    {

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Sku> Skus { get; set; }

        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

    }
}
