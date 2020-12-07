using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using ShoppApi.Controllers;
using ShoppApi.DTO;
using ShoppApi.Model;
using ShoppApi.Model.Request;
using ShoppApi.Model.Response;
using ShoppApi.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Controllers
{
    public class CartControllerTest
    {

        private readonly String CART_ID;

        private readonly Guid SKU_ID;

        private readonly int PRODUCT_COUNT;

        private CartController controller;

        private ICartService service;

        private PostAddProductRequest postAddProductRequest;

        private PutAddProductRequest putAddProductRequest;

        private DeleteAddProductRequest deleteAddProductRequest;

        private GetCartResponse successGetCartResponse;

        private PostCartResponse successPostCartResponse;

        private PostAddCartResponse successPostAddCartResponse;

        private PutAddCartResponse successPutAddCartResponse;

        private DeleteCartResponse successDeleteCartResponse;

        public CartControllerTest()
        {
            CART_ID = "a717372b-ca98-40e1-9606-2e3503aa756c";
            SKU_ID = Guid.NewGuid();
            PRODUCT_COUNT = 1;

            this.StartupData();
            this.StartupMock();
        }

        private void StartupData()
        {

            this.postAddProductRequest = new PostAddProductRequest();
            this.postAddProductRequest.SkuId = SKU_ID;
            this.postAddProductRequest.Count = PRODUCT_COUNT;

            this.putAddProductRequest = new PutAddProductRequest();
            this.putAddProductRequest.SkuId = SKU_ID;
            this.putAddProductRequest.Count = PRODUCT_COUNT;

            this.deleteAddProductRequest = new DeleteAddProductRequest();
            this.deleteAddProductRequest.SkuId = SKU_ID;

            Sku sku = new Sku();
            sku.Oid = Guid.NewGuid();
            sku.Price = 15;
            sku.Inventory = 10;
            sku.Description = "Camisa azul";

            List<CartProduct> products = new List<CartProduct>();

            CartProduct cartProduct01 = new CartProduct();

            cartProduct01.Id = Guid.NewGuid();
            cartProduct01.Sku = sku;
            cartProduct01.Count = 1;

            products.Add(cartProduct01);

            Cart cart = new Cart();
            cart.Id = CART_ID;
            cart.Products = products;

            Cart cart02 = new Cart();
            cart.Id = CART_ID;

            this.successGetCartResponse = new GetCartResponse();
            this.successGetCartResponse.Cart = cart;
            this.successGetCartResponse.StatusCode = StatusCodes.Status200OK;

            this.successPostCartResponse = new PostCartResponse();
            this.successPostCartResponse.Cart = cart02;
            this.successPostCartResponse.StatusCode = StatusCodes.Status201Created;

            this.successPostAddCartResponse = new PostAddCartResponse();
            this.successPostAddCartResponse.Cart = cart;
            this.successPostAddCartResponse.StatusCode = StatusCodes.Status200OK;

            this.successPutAddCartResponse = new PutAddCartResponse();
            this.successPutAddCartResponse.Cart = cart;
            this.successPutAddCartResponse.StatusCode = StatusCodes.Status200OK;

            this.successDeleteCartResponse = new DeleteCartResponse();
            this.successDeleteCartResponse.Cart = cart;
            this.successDeleteCartResponse.StatusCode = StatusCodes.Status200OK;

        }

        private void StartupMock()
        {
            this.service = Substitute.For<ICartService>();
            this.controller = new CartController(this.service);
        }

        [Fact]
        public void returnSuccessWhenCartExists()
        {

            this.service
                .GetCart(CART_ID)
                .Returns(successGetCartResponse);

            var okResult = this.controller.Get(CART_ID) as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult.StatusCode == StatusCodes.Status200OK);
            Assert.NotNull(okResult.Value);
            Assert.NotNull((okResult.Value as Cart).Products);

        }

        [Fact]
        public void returnSuccessWhenCartCreated()
        {

            this.service
                .PostCart()
                .Returns(successPostCartResponse);

            var createdAtActionResult = this.controller.Post() as CreatedAtActionResult;

            Assert.NotNull(createdAtActionResult);
            Assert.True(createdAtActionResult.StatusCode == StatusCodes.Status201Created);
            Assert.NotNull(createdAtActionResult.Value);
            Assert.NotNull((createdAtActionResult.Value as Cart).Products);
            Assert.Empty((createdAtActionResult.Value as Cart).Products);

        }

        [Fact]
        public void returnSuccessWhenPostNewProductForCart()
        {

            this.service
                .AddNewProduct(CART_ID, SKU_ID, PRODUCT_COUNT)
                .Returns(successPostAddCartResponse);

            var okResult = this.controller.Post(CART_ID, postAddProductRequest) as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult.StatusCode == StatusCodes.Status200OK);
            Assert.NotNull(okResult.Value);
            Assert.NotNull((okResult.Value as Cart).Products);

        }

        [Fact]
        public void returnSuccessWhenUpdateProductFromCart()
        {

            this.service
                .UpdateProduct(CART_ID, SKU_ID, PRODUCT_COUNT)
                .Returns(successPutAddCartResponse);

            var okResult = this.controller.Put(CART_ID, putAddProductRequest) as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult.StatusCode == StatusCodes.Status200OK);
            Assert.NotNull(okResult.Value);
            Assert.NotNull((okResult.Value as Cart).Products);

        }

        [Fact]
        public void returnSuccessWhenDeleteProductFromCart()
        {

            this.service
                .DeleteProduct(CART_ID, SKU_ID)
                .Returns(successDeleteCartResponse);

            var okResult = this.controller.Delete(CART_ID, deleteAddProductRequest) as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.True(okResult.StatusCode == StatusCodes.Status200OK);
            Assert.NotNull(okResult.Value);
            Assert.NotNull((okResult.Value as Cart).Products);

        }

    }
}
