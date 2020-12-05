using ShoppApi.Common;
using ShoppApi.DTO;
using ShoppApi.Model.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model
{
    public class Cart
    {

        [Key]
        public String Id { get; set; }

        public List<CartProduct> Products { get; set; }

        public Double CartTotalPrice { get { return CalcCart.TotalPrice(Products); } }

        public int ProductsCount { get { return this.Products.Count(); } }

        public Cart()
        {
            if (this.Products == null)
                this.Products = new List<CartProduct>();
        }

        public Cart(String Id)
        {
            this.Id = Id;
            if (this.Products == null)
                this.Products = new List<CartProduct>();
        }

        internal void AddSkuToCart(Sku sku, int count, bool update)
        {

            CartProduct foundCartProduct = this.Products.Where(p => p.Sku.Oid.Equals(sku.Oid)).FirstOrDefault();

            if (foundCartProduct == null)
            {
                this.Products.Add(
                    new CartProductBuilder()
                        .Sku(sku)
                        .Count(count)
                        .UnitValue(sku.Price)
                        .Build()
                 );
            } else
            {
                if (update)
                    foundCartProduct.Count = count;
                else
                    foundCartProduct.Count += count;
            }

        }

        internal void RemoveSkuFromCart(Guid skuId)
        {
            CartProduct removableCartProductDTO = null;

            this.Products.ForEach(p => {
                if (p.Sku.Oid == skuId)
                    removableCartProductDTO = p;
            });

            if (removableCartProductDTO != null)
                this.Products.Remove(removableCartProductDTO);
        }

    }
}
