using ShoppApi.DTO;
using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Model
{
    public class CartProductTest
    {

        private Sku sku;

        public CartProductTest()
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
        }

        [Fact]
        public void returnSuccessWhenEntityIsNotNull()
        {

            CartProduct cartProduct01 = new CartProduct();

            cartProduct01.Id = Guid.NewGuid();
            cartProduct01.Sku = sku;
            cartProduct01.Count = 1;

            Assert.NotNull(cartProduct01);

        }

    }
}
