using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Model
{
    public class SkuTest
    {
        [Fact]
        public void returnSuccessWhenEntityIsNotNull()
        {

            Sku sku = new Sku();

            sku.Oid = Guid.NewGuid();
            sku.Price = 15;
            sku.Inventory = 10;
            sku.Description = "Camisa azul";

            Assert.NotNull(sku);

        }
    }
}
