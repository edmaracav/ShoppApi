using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoppApi.Model;
using ShoppApi.Repositories.Cache;
using ShoppApi.Repositories.Contexts;
using ShoppApi.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Repositories
{
    public class CartRepository : ICartRepository
    {

        private DatabaseContext context;

        private RedisConnection redisConnection;

        public CartRepository(DatabaseContext context, [FromServices] RedisConnection redisConnection)
        {
            this.context = context;
            this.redisConnection = redisConnection;
        }

        public void AddCartToCache(Cart cart)
        {
            String cartJson = JsonConvert.SerializeObject(cart);
            this.redisConnection.SetValue(cart.Id, cartJson);
        }

        public Cart CreateCart()
        {
            Cart cart = new Cart(Guid.NewGuid().ToString());

            this.context.carts.Add(cart);
            this.context.SaveChanges();

            this.AddCartToCache(cart);

            return cart;
        }

        public Cart getCart(string id)
        {
            return this.context
                    .carts
                    .Where(c => c.Id.Equals(id))
                    .Include(c => c.Products)
                    .FirstOrDefault();
        }

        public Cart getCartFromCache(string id)
        {
            String cartJson = this.redisConnection.GetValueFromKey(id);
            return cartJson == null ? null : JsonConvert.DeserializeObject<Cart>(cartJson);
        }

        public void SaveOrUpdateCart(Cart cart)
        {
            this.context.carts.Update(cart);
            this.context.SaveChanges();

            this.AddCartToCache(cart);
        }
    }
}
