using ShoppApi.DTO;
using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Model
{
    public class CartTest
    {

        private List<CartProduct> products;

        private Sku sku;

        public CartTest()
        {
            this.StartupData();
        }

        private void StartupData()
        {
            sku = new Sku();
            sku.Oid = Guid.NewGuid();
            sku.Price = 15;
            sku.Inventory = 10;
            sku.Description = "Camisa azul";

            products = new List<CartProduct>();

            CartProduct cartProduct01 = new CartProduct();

            cartProduct01.Id = Guid.NewGuid();
            cartProduct01.Sku = sku;
            cartProduct01.Count = 1;

            products.Add(cartProduct01);

        }

        [Fact]
        public void returnSuccessWhenEntityIsNotNull()
        {

            Cart cart = new Cart();

            cart.Id = Guid.NewGuid().ToString();

            Assert.NotNull(cart);

        }

        [Fact]
        public void returnSuccessWhenEntityIsNotNullAndProductsCountGreaterThanZero()
        {

            Cart cart = new Cart();

            cart.Id = Guid.NewGuid().ToString();
            cart.Products = this.products;

            Assert.NotNull(cart);
            Assert.NotEmpty(cart.Products);
            Assert.True(cart.Products.Count > 0);

        }

    }
}
