using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppApi.Model
{
    [Table("products")]
    public class Product
    {
        
        [Key]
        public Guid Oid { get; set; }
        
        public string Name { get; set; }
        
        public byte[] Image { get; set; }

        public List<Sku> Skus { get; set; }
    }
}
