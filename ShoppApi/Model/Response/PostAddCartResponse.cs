using ShoppApi.Common;
using ShoppApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model.Response
{
    public class PostAddCartResponse : CartResponse
    {
        public PostAddCartResponse(string errorMessage) : base(errorMessage)
        {

        }

        internal void AddSkuCount(Sku sku, int count)
        {
            this.Products.ForEach(p =>
            {
                if (p.Sku.Oid == sku.Oid)
                    p.Count += count;
            });
        }
    }
}
