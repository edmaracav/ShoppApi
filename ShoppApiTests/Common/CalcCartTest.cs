using ShoppApi.Common;
using ShoppApi.DTO;
using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Common
{
    public class CalcCartTest
    {
        private List<CartProduct> products;

        public CalcCartTest()
        {
            this.StartupData();
        }

        private void StartupData()
        {
            this.products = new List<CartProduct>();
            
            Sku sku = new Sku();

            sku.Oid = Guid.NewGuid();
            sku.Price = 15;
            sku.Inventory = 10;
            sku.Description = "Camisa azul";

            CartProduct cartProduct01 = new CartProduct();
            cartProduct01.Id = Guid.NewGuid();
            cartProduct01.Count = 2;
            cartProduct01.UnitValue = 15;
            cartProduct01.Sku = sku;

        }

        [Fact]
        public void returnSuccessWhenCalcAreSuccessfull()
        {

            Double totalPrice = CalcCart.TotalPrice(products);

            Assert.True(totalPrice >= 0);

        }

    }
}
