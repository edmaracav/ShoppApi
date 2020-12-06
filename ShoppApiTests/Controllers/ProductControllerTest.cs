using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NSubstitute;
using ShoppApi.Controllers;
using ShoppApi.Model;
using ShoppApi.Model.Response;
using ShoppApi.Service;
using ShoppApi.Service.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Controllers
{
    public class ProductControllerTest
    {

        private ProductController controller;

        private IProductService service;

        private GetProductResponse successGetProductResponse;
        
        private GetProductResponse notFoundGetProductResponse;
        
        private GetProductResponse errorGetProductResponse;

        private readonly String NOT_FOUN_PRODUCTS = "Nenhum produto encontrado.";

        public ProductControllerTest()
        {
            this.StartupData();
            this.StartupMock();
        }

        private void StartupData()
        {

            List<Product> products = new List<Product>();

            Product product01 = new Product();
            product01.Oid = Guid.NewGuid();
            product01.Name = "Camisa";

            products.Add(product01);

            successGetProductResponse = new GetProductResponse();
            successGetProductResponse.Products = products;
            successGetProductResponse.StatusCode = StatusCodes.Status200OK;

            notFoundGetProductResponse = new GetProductResponse();
            notFoundGetProductResponse.Products = new List<Product>();
            notFoundGetProductResponse.StatusCode = StatusCodes.Status404NotFound;
            notFoundGetProductResponse.ErrorMessage = NOT_FOUN_PRODUCTS;

            errorGetProductResponse = new GetProductResponse();
            errorGetProductResponse.ErrorMessage = "Internal Server Error";
            errorGetProductResponse.StatusCode = StatusCodes.Status500InternalServerError;

        }

        private void StartupMock()
        {
            this.service = Substitute.For<IProductService>();
            this.controller = new ProductController(this.service);
        }

        [Fact]
        public void returnSuccessWhenHaveProducts()
        {

            service
                .GetAllProducts()
                .Returns(successGetProductResponse);

            var okResult = this.controller.Get() as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult.StatusCode == StatusCodes.Status200OK);
            Assert.NotNull(okResult.Value);
            Assert.NotEmpty(okResult.Value as List<Product>);
            Assert.True((okResult.Value as List<Product>).Count > 0);

        }

        [Fact]
        public void returnSuccessWhenDontHaveProducts()
        {

            service
                .GetAllProducts()
                .Returns(notFoundGetProductResponse);

            var notFoundResult = this.controller.Get() as NotFoundObjectResult;

            Assert.NotNull(notFoundResult);
            Assert.True(notFoundResult.StatusCode == StatusCodes.Status404NotFound);
            Assert.NotNull(notFoundResult.Value);
            Assert.Empty((notFoundResult.Value as GetProductResponse).Products);
            Assert.True((notFoundResult.Value as GetProductResponse).Products.Count == 0);
            Assert.Equal(NOT_FOUN_PRODUCTS, (notFoundResult.Value as GetProductResponse).ErrorMessage);

        }

        [Fact]
        public void returnErrorWhenTryGetAllProducts()
        {

            service
                .GetAllProducts()
                .Returns(errorGetProductResponse);

            var internalServerErrorResult = this.controller.Get() as StatusCodeResult;

            Assert.NotNull(internalServerErrorResult);
            Assert.True(internalServerErrorResult.StatusCode == StatusCodes.Status500InternalServerError);

        }

    }
}
