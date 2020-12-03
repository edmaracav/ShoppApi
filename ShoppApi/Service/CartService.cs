using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ShoppApi.Model;
using ShoppApi.Model.Response;
using ShoppApi.Repositories.Contexts;
using ShoppApi.Repositories.Contracts;
using ShoppApi.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Service
{
    public class CartService : ICartService
    {
        private readonly ILogger logger;

        private readonly ICartRepository cartRepository;

        private readonly ISkuRepository skuRepository;

        public CartService(ILogger<CartService> logger, ICartRepository cartRepository, ISkuRepository skuRepository)
        {
            this.logger = logger;
            this.cartRepository = cartRepository;
            this.skuRepository = skuRepository;
        }

        public GetCartResponse GetCart(String id)
        {
            Cart cart = null;
            GetCartResponse response = new GetCartResponse();

            logger.LogInformation("CartService.GetCart - Start.");

            if (id.Equals(String.Empty))
            {
                logger.LogInformation("CartService.GetCart - ID is empty, create new cart.");
                cart = this.CreateCart();
            }
            else
            {
                cart = this.GetCartFromRepository(id);

                if (cart == null)
                {
                    logger.LogInformation("CartService.GetCart - Not found cart, create new cart.");
                    cart = this.CreateCart();
                }

            }

            response.Cart = cart;

            logger.LogInformation("CartService.GetCart - End.");

            return response;
        }

        public PostAddCartResponse AddNewProduct(String id, Sku sku, int count)
        {
            Cart cart = null;
            PostAddCartResponse response = new PostAddCartResponse();

            logger.LogInformation("CartService.AddNewProduct - Start.");

            if (count <= 0)
            {
                logger.LogInformation("CartService.AddNewProduct - Products count is 0 or less.");

                response.ErrorMessage = "Adding items with zeroed quantity is not allowed";
                response.StatusCode = StatusCodes.Status406NotAcceptable;

                return response;
            }

            Sku foundSku = this.GetSku(sku.Oid);

            if (foundSku != null)
            {

                if (count > foundSku.Inventory)
                {
                    logger.LogInformation("CartService.AddNewProduct - Count is more then inventory.");

                    response.ErrorMessage = "Adding more products than is in stock is not allowed";
                    response.StatusCode = StatusCodes.Status406NotAcceptable;

                    return response;
                }

                cart = this.GetCartFromRepository(id);

                if (cart == null)
                {
                    logger.LogInformation("CartService.AddNewProduct - Not found cart.");
                    response.StatusCode = StatusCodes.Status404NotFound;

                    return response;
                }

                cart.AddSkuToCart(foundSku, count, false);

                this.SaveCart(cart);

                response.Cart = cart;
                response.StatusCode = StatusCodes.Status200OK;

            }
            else
            {
                response.ErrorMessage = "Sku not found";
                response.StatusCode = StatusCodes.Status404NotFound;
            }

            logger.LogInformation("CartService.AddNewProduct - End.");

            return response;
        }

        public PutAddCartResponse UpdateProduct(String id, Sku sku, int count)
        {

            Cart cart = null;
            PutAddCartResponse response = new PutAddCartResponse();

            logger.LogInformation("CartService.UpdateProduct - Start.");

            if (count <= 0)
            {
                logger.LogInformation("CartService.UpdateProduct - Products count is 0 or less.");

                response.ErrorMessage = "Adding items with zeroed quantity is not allowed";
                response.StatusCode = StatusCodes.Status406NotAcceptable;

                return response;
            }

            Sku foundSku = this.GetSku(sku.Oid);

            if (foundSku != null)
            {

                if (count > foundSku.Inventory)
                {
                    logger.LogInformation("CartService.UpdateProduct - Count is more then inventory.");
                    response.ErrorMessage = "Adding more products than is in stock is not allowed";
                    response.StatusCode = StatusCodes.Status406NotAcceptable;

                    return response;
                }

                cart = this.GetCartFromRepository(id);

                if (cart == null)
                {
                    logger.LogInformation("CartService.UpdateProduct - Not found cart.");
                    response.StatusCode = StatusCodes.Status404NotFound;

                    return response;
                }

                cart.AddSkuToCart(foundSku, count, true);

                this.SaveCart(cart);

                response.Cart = cart;
                response.StatusCode = StatusCodes.Status200OK;

            }
            else
            {
                response.ErrorMessage = "Sku not found";
                response.StatusCode = StatusCodes.Status404NotFound;
            }

            logger.LogInformation("CartService.UpdateProduct - End.");

            return response;

        }

        public DeleteCartResponse DeleteProduct(String id, Sku sku)
        {
            Cart cart = null;
            DeleteCartResponse response = new DeleteCartResponse();

            logger.LogInformation("CartService.DeleteProduct - Start.");

            Sku foundSku = this.GetSku(sku.Oid);

            if (foundSku != null)
            {

                cart = this.GetCartFromRepository(id);

                if (response == null)
                {
                    logger.LogInformation("CartService.DeleteProduct - Not found cart.");
                    response.StatusCode = StatusCodes.Status404NotFound;
                }

                cart.RemoveSkuFromCart(sku);

                this.SaveCart(cart);

                response.Cart = cart;
                response.StatusCode = StatusCodes.Status200OK;
            }

            logger.LogInformation("CartService.DeleteProduct - End.");

            return response;
        }

        private Cart GetCartFromRepository(string id)
        {
            // Buscar carrinho em cache
            Cart cart = this.cartRepository.getCartFromCache(id);

            if (cart == null)
            {
                // Caso o carrinho não exista em cache, buscar no banco.
                cart = this.cartRepository.getCart(id);

                if (cart != null)
                    this.cartRepository.AddCartToCache(cart);
            }

            return cart;
        }

        private Cart CreateCart()
        {
            return this.cartRepository.CreateCart();
        }

        private Sku GetSku(Guid oid)
        {
            return this.skuRepository.FindSku(oid);
        }

        private void SaveCart(Cart cart)
        {
            this.cartRepository.SaveOrUpdateCart(cart);
        }

        public PostCartResponse PostCart()
        {
            PostCartResponse response = new PostCartResponse();

            logger.LogInformation("CartService.PostCart - Start.");

            Cart cart = this.CreateCart();

            response.Cart = cart;

            logger.LogInformation("CartService.PostCart - End.");

            return response;
        }
    }
}
