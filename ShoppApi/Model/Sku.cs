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
        public string Inventory { get; set; }
        public  double  Price { get; set; }
        public Product Product { get; set; }
    }
}
