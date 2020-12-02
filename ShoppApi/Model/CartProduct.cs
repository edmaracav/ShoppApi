using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.DTO
{
    public class CartProduct
    {
        
        [Key]
        public Guid Id { get; set; }

        public Sku Sku { get; set; }

        public int Count { get; set; }

        public Double UnitValue { get; set; }

        public Double TotalValue { get { return this.UnitValue * this.Count; } }
    }
}
