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

        public DbSet<Cart> carts { get; set; }

        public DbSet<Sku> skus { get; set; }

        public DbSet<Product> products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

    }
}
