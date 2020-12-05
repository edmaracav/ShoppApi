using ShoppApi.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Service.Contracts
{
    public interface IProductService
    {
        public GetProductResponse GetAllProducts();
    }
}
