using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Repositories.Contracts
{
    public interface ICartRepository
    {
        Cart getCartFromCache(string id);
        Cart getCart(string id);
        Cart CreateCart();
        void SaveOrUpdateCart(Cart cart);
        void AddCartToCache(Cart cart);
    }
}
