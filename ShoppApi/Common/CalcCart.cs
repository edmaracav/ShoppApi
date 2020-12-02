using ShoppApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Common
{
    public class CalcCart
    {
        public static Double TotalPrice(List<CartProduct> products)
        {
            Double cartTotalPrice = 0;

            products?.ForEach(p => cartTotalPrice += p.TotalValue);

            return cartTotalPrice;
        }
    }
}
