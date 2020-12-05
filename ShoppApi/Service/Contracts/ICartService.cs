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

        public PostCartResponse PostCart();

        public PostAddCartResponse AddNewProduct(String id, Guid skuId, int count);

        public PutAddCartResponse UpdateProduct(String id, Guid skuId, int count);

        public DeleteCartResponse DeleteProduct(String id, Guid skuId);

    }
}
