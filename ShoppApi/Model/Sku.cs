using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppApi.Model
{
    [Table("skus")]
    public class Sku
    {
        [Key]
        public Guid Oid { get; set; }
        public int Inventory { get; set; }
        public  Double  Price { get; set; }
        public Product Product { get; set; }
    }
}
