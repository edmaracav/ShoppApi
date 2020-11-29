using Microsoft.AspNetCore.Mvc;
using ShoppApi.Model.Request;
using ShoppApi.Model.Response;
using ShoppApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private CartService cartService;

        public CartController(CartService cartService)
        {
            this.cartService = cartService;
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public GetCartResponse Get(String id)
        {
            return this.cartService.GetCart(id);
        }

        // POST api/<CartController>/addProduct
        [HttpPost("/addProduct")]
        public PostAddCartResponse Post([FromBody] PostAddProductRequest request)
        {
            return this.cartService.AddNewProduct(request.Sku, request.Count);
        }

        // PUT api/<CartController>/updateProduct
        [HttpPut("/updateProduct/{id}")]
        public PutAddCartResponse Put(int id, [FromBody] PutAddProductRequest request)
        {
            return this.cartService.UpdateProduct(request.Sku, request.Count);
        }

        // DELETE api/<CartController>/5
        [HttpDelete()]
        public void Delete([FromBody] DeleteAddProductRequest request)
        {
            this.cartService.DeleteProduct(request.Sku);
        }
    }
}
