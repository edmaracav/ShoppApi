using ShoppApi.Model;
using ShoppApi.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Service.Contracts
{
    public interface ICartService
    {

        public GetCartResponse GetCart(String id);

        public PostAddCartResponse AddNewProduct(String id, Sku sku, int count);

        public PutAddCartResponse UpdateProduct(String id, Sku sku, int count);

        public DeleteCartResponse DeleteProduct(String id, Sku sku);

    }
}
