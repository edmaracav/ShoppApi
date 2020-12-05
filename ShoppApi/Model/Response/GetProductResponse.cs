using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model.Response
{
    public class GetProductResponse : DefaultResponse
    {
        public List<Product> Products { get; set; }
    }
}
