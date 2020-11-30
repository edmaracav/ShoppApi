using ShoppApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Model.Builders
{
    public class CartProductBuilder
    {

        private readonly CartProduct cartProduct;

        public CartProductBuilder()
        {
            this.cartProduct = new CartProduct();
        }

        public CartProduct Build()
        {
            return this.cartProduct;
        }

        public CartProductBuilder Sku(Sku Sku)
        {
            this.cartProduct.Sku = Sku;
            return this;
        }

        public CartProductBuilder Count(int Count)
        {
            this.cartProduct.Count = Count;
            return this;
        }

        public CartProductBuilder UnitValue(Double UnitValue)
        {
            this.cartProduct.UnitValue = UnitValue;
            return this;
        }

    }
}
