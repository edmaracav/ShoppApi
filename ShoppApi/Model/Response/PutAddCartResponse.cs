using ShoppApi.Common;
using ShoppApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model.Response
{
    public class PutAddCartResponse
    {
        public List<CartProductDTO> Products { get; set; }

        public Double CartTotalPrice { get { return CalcCart.TotalPrice(Products); } }

        public int ProductsCount { get { return this.Products.Count(); } }
    }
}
