using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Model
{
    public class ProductTest
    {

        private List<Sku> Skus;

        public ProductTest()
        {
            this.StartupData();
        }

        private void StartupData()
        {

            this.Skus = new List<Sku>();

            Sku sku01 = new Sku();
            sku01.Oid = Guid.NewGuid();
            sku01.Price = 15;
            sku01.Inventory = 10;
            sku01.Description = "Camisa azul";

            Sku sku02 = new Sku();
            sku02.Oid = Guid.NewGuid();
            sku02.Price = 12;
            sku02.Inventory = 4;
            sku02.Description = "Camisa vermelha";

            this.Skus.Add(sku01);
            this.Skus.Add(sku02);

        }

        [Fact]
        public void returnSuccessWhenEntityIsNotNull()
        {

            Product product = new Product();

            product.Oid = Guid.NewGuid();
            product.Name = "Camisa";

            Assert.NotNull(product);

        }

        [Fact]
        public void returnSuccessWhenEntityIsNotNullAndSkusCountGreaterThanZero()
        {

            Product product = new Product();

            product.Oid = Guid.NewGuid();
            product.Name = "Camisa";
            product.Skus = this.Skus;

            Assert.NotNull(product);
            Assert.NotEmpty(product.Skus);
            Assert.True(product.Skus.Count > 0);

        }

    }
}
