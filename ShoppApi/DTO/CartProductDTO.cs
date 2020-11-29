using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.DTO
{
    public class CartProductDTO
    {
        public Sku Sku { get; set; }

        public int Count { get; set; }

        public Double UnitValue { get; set; }

        public Double TotalValue { get { return this.UnitValue * this.Count; } }
    }
}
