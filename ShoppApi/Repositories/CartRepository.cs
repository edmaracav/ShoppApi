using Microsoft.EntityFrameworkCore;
using ShoppApi.Model;
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

        public CartRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void AddCartToCache(Cart cart)
        {
            
        }

        public Cart CreateCart()
        {
            Cart cart = new Cart(Guid.NewGuid().ToString());

            this.context.carts.Add(cart);
            this.context.SaveChanges();

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
            return null;
        }

        public void SaveOrUpdateCart(Cart cart)
        {
            this.context.carts.Update(cart);
            this.context.SaveChanges();
        }
    }
}
