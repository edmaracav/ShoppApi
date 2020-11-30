using Microsoft.Extensions.Logging;
using ShoppApi.Model;
using ShoppApi.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Service
{
    public class CartService
    {
        private readonly ILogger logger;

        public CartService(ILogger<CartService> logger)
        {
            this.logger = logger;
        }

        internal GetCartResponse GetCart(String id)
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

                response.Cart = cart;
            }

            logger.LogInformation("CartService.GetCart - End.");

            return response;
        }

        internal PostAddCartResponse AddNewProduct(String id, Sku sku, int count)
        {
            Cart cart = null;
            PostAddCartResponse response = new PostAddCartResponse();

            logger.LogInformation("CartService.AddNewProduct - Start.");

            if (count <= 0)
            {
                logger.LogInformation("CartService.AddNewProduct - Products count is 0 or less.");

                response.ErrorMessage = "Adding items with zeroed quantity is not allowed";

                return response;
            }

            Sku foundSku = this.GetSku(sku.Oid);

            if (foundSku != null)
            {

                if (count > foundSku.Inventory)
                {
                    logger.LogInformation("CartService.AddNewProduct - Count is more then inventory.");

                    response.ErrorMessage = "adding more products than is in stock is not allowed";
                }

                cart = this.GetCartFromRepository(id);

                if (cart == null)
                {
                    logger.LogInformation("CartService.AddNewProduct - Not found cart.");

                    return response;
                }

                cart.AddSkuToCart(foundSku, count, false);

                this.SaveCart(cart);

            }
            else
            {
                response.ErrorMessage = "sku not found";
            }

            logger.LogInformation("CartService.AddNewProduct - End.");

            return response;
        }

        internal PutAddCartResponse UpdateProduct(String id, Sku sku, int count)
        {

            Cart cart = null;
            PutAddCartResponse response = new PutAddCartResponse();

            logger.LogInformation("CartService.UpdateProduct - Start.");

            Sku foundSku = this.GetSku(sku.Oid);

            if (foundSku != null)
            {

                if (count > foundSku.Inventory)
                {
                    logger.LogInformation("CartService.UpdateProduct - Count is more then inventory.");
                    response.ErrorMessage = "adding more products than is in stock is not allowed";
                }

                cart = this.GetCartFromRepository(id);

                if (cart == null)
                {
                    logger.LogInformation("CartService.UpdateProduct - Not found cart.");
                    return response;
                }

                cart.AddSkuToCart(foundSku, count, true);

                this.SaveCart(cart);

            }
            else
            {
                response.ErrorMessage = "sku not found";
            }

            logger.LogInformation("CartService.UpdateProduct - End.");

            return response;

        }

        internal DeleteCartResponse DeleteProduct(String id, Sku sku)
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
                }

                cart.RemoveSkuFromCart(sku);

                this.SaveCart(cart);

            }

            logger.LogInformation("CartService.DeleteProduct - End.");

            return response;
        }

        private Cart GetCartFromRepository(string id)
        {
            throw new NotImplementedException();
        }

        private Cart CreateCart()
        {
            throw new NotImplementedException();
        }

        private Sku GetSku(Guid oid)
        {
            throw new NotImplementedException();
        }

        private void SaveCart(Cart cart)
        {
            throw new NotImplementedException();
        }

    }
}
