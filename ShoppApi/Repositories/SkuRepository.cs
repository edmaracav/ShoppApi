using ShoppApi.Model;
using ShoppApi.Repositories.Contexts;
using ShoppApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Repositories
{
    public class SkuRepository : ISkuRepository
    {

        private DatabaseContext context;

        public SkuRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Sku FindSku(Guid oid)
        {
            return this.context
                    .skus
                    .Where(s => s.Oid.Equals(oid))
                    .FirstOrDefault();
        }
    }
}
