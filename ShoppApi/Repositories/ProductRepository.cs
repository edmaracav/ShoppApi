using Microsoft.EntityFrameworkCore;
using ShoppApi.Model;
using ShoppApi.Repositories.Contexts;
using ShoppApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext context;

        public ProductRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public List<Product> GetAll()
        {
            return this.context
                    .Products
                    .Include(p => p.Skus)
                    .ToList();
        }
    }
}
