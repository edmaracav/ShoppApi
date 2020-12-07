using Microsoft.Extensions.Logging;
using NSubstitute;
using ShoppApi.Model;
using ShoppApi.Repositories.Contracts;
using ShoppApi.Service;
using ShoppApi.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ShoppApiTests.Service
{
    public class CartServiceTest
    {

        private ICartService service;

        private ICartRepository cartRepository;

        private ISkuRepository skuRepository;

        private ILogger<CartService> logger;

        private String CART_ID_CACHE = "aa2978ce-3824-11eb-adc1-0242ac120002";

        private Cart CacheCart;

        public CartServiceTest()
        {
            this.StartupData();
            this.StartupMock();
        }

        private void StartupData()
        {

            

        }

        private void StartupMock()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddConsole()
                    .AddEventLog();
            });

            this.logger = loggerFactory.CreateLogger<CartService>();

            this.cartRepository = Substitute.For<ICartRepository>();
            this.skuRepository = Substitute.For<ISkuRepository>();
            this.service = new CartService(this.logger, this.cartRepository, this.skuRepository);
        }

        [Fact]
        public void returnSuccessWhenGetAlreadExistsCartOnCache()
        {

            this.cartRepository
                .getCartFromCache(CART_ID_CACHE)
                .Returns(this.CacheCart);

        }

        [Fact]
        public void returnSuccessWhenGetAlreadExistsCartOnDatabase()
        {

        }

        [Fact]
        public void returnSuccessWhenGetNewCartWithEmptyID()
        {

        }

        [Fact]
        public void returnSuccessWhenGetNewCartWithParamID()
        {

        }

        [Fact]
        public void returnErrorWhenTryAddNewProductWithZeroCount()
        {

        }

        [Fact]
        public void returnErrorWhenTryAddNewProductButSkuNotFound()
        {

        }

        [Fact]
        public void returnErrorWhenTryAddNewProductWithCountLessThanInventory()
        {

        }

        [Fact]
        public void returnErrorWhenTryAddNewProductOnCartWhatNotExists()
        {

        }

        [Fact]
        public void returnSuccessWhenAddNewProductOnCart()
        {

        }

        [Fact]
        public void returnSuccessWhenTryAddNewProductButHasProductOnCart()
        {

        }

        [Fact]
        public void returnErrorWhenTryUpdateProductWithZeroCount()
        {

        }

        [Fact]
        public void returnErrorWhenTryUpdateProductButSkuNotFound()
        {

        }

        [Fact]
        public void returnErrorWhenTryUpdateProductWithCountLessThanInventory()
        {

        }

        [Fact]
        public void returnErrorWhenTryUpdateProductOnCartWhatNotExists()
        {

        }

        [Fact]
        public void returnSuccessWhenUpdateProductOnCart()
        {

        }

        [Fact]
        public void returnErrorWhenTryDeleteProductButCartNotFound()
        {

        }

        [Fact]
        public void returnSuccessWhenDeleteProductFromCart()
        {

        }

        [Fact]
        public void returnSuccessWhenCreateNewCart()
        {

        }

    }
}
