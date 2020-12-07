using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NSubstitute;
using ShoppApi.Model;
using ShoppApi.Model.Response;
using ShoppApi.Repositories;
using ShoppApi.Repositories.Contracts;
using ShoppApi.Service;
using ShoppApi.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Service
{
    public class ProductServiceTest
    {

        private IProductService service;

        private IProductRepository repository;

        private ILogger<ProductService> logger;

        private List<Product> products;
        
        private List<Product> notFoundProducts;

        public ProductServiceTest()
        {
            this.StartupData();
            this.StartupMock();
        }

        private void StartupData()
        {
            this.products = new List<Product>();
            this.notFoundProducts = null;

            Product product01 = new Product();
            product01.Oid = Guid.NewGuid();
            product01.Name = "Camisa";

            products.Add(product01);
        }

        private void StartupMock()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddConsole()
                    .AddEventLog();
            });

            this.logger = loggerFactory.CreateLogger<ProductService>();

            this.repository = Substitute.For<IProductRepository>();
            this.service = new ProductService(this.logger, this.repository);
        }

        [Fact]
        public void returnSuccessWhenGetProducts()
        {

            this.repository
                .GetAll()
                .Returns(this.products);

            GetProductResponse response = this.service.GetAllProducts();

            Assert.NotNull(response);
            Assert.NotNull(response.Products);
            Assert.True(response.StatusCode == StatusCodes.Status200OK);
            Assert.True(response.Products.Count > 0);

        }

        [Fact]
        public void returnSuccessWhenNotFoundProducts()
        {

            this.repository
                .GetAll()
                .Returns(this.notFoundProducts);

            GetProductResponse response = this.service.GetAllProducts();

            Assert.NotNull(response);
            Assert.Null(response.Products);
            Assert.True(response.StatusCode == StatusCodes.Status404NotFound);

        }

    }
}
