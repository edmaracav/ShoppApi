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
            GetCartResponse cart = null;

            logger.LogInformation("CartService.GetCart - Start.");

            if (id.Equals(String.Empty))
            {
                logger.LogInformation("CartService.GetCart - ID is empty, create new cart.");
                cart = this.AddNewCart();
            } else
            {
                cart = this.CheckCart<GetCartResponse>(id);

                if (cart == null)
                {
                    logger.LogInformation("CartService.GetCart - Not found cart, create new cart.");
                    cart = this.AddNewCart();
                }
            }

            logger.LogInformation("CartService.GetCart - End.");

            return cart;
        }

        internal PostAddCartResponse AddNewProduct(Sku sku, int count)
        {
            PostAddCartResponse cart = null;

            logger.LogInformation("CartService.AddNewProduct - Start.");

            if (count <= 0)
            {
                logger.LogInformation("CartService.AddNewProduct - Products count is 0 or less.");

                cart = new PostAddCartResponse("Adding items with zeroed quantity is not allowed");
            }

            Sku foundSku = this.GetSku(sku.Oid);

            if (count > foundSku.Inventory)
            {
                logger.LogInformation("CartService.AddNewProduct - Count is more then inventory.");

                cart = new PostAddCartResponse("adding more products than is in stock is not allowed");
            }

            cart = this.CheckCart<PostAddCartResponse>(sku.Oid.ToString());

            if (cart == null)
            {
                logger.LogInformation("CartService.AddNewProduct - Not found cart.");
            }

            cart.AddSkuCount(sku, count);

            this.SaveCart(cart);

            logger.LogInformation("CartService.AddNewProduct - End.");

            return cart;
        }

        private Sku GetSku(Guid oid)
        {
            throw new NotImplementedException();
        }

        private void SaveCart(PostAddCartResponse cart)
        {
            throw new NotImplementedException();
        }

        internal PutAddCartResponse UpdateProduct(Sku sku, int count)
        {
            throw new NotImplementedException();
        }

        private T CheckCart<T>(string id)
        {
            throw new NotImplementedException();
        }

        internal void DeleteProduct(Sku sku)
        {
            throw new NotImplementedException();
        }

        private GetCartResponse AddNewCart()
        {
            throw new NotImplementedException();
        }
    }
}
