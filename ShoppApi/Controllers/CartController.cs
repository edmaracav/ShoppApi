using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppApi.Model.Request;
using ShoppApi.Model.Response;
using ShoppApi.Service;
using ShoppApi.Service.Contracts;
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
        private ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get(String id)
        {
            return Ok(this.cartService.GetCart(id).Cart);
        }

        // POST api/<CartController>/
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Post()
        {
            return Ok(this.cartService.PostCart().Cart);
        }

        // POST api/<CartController>/{id}/addProduct
        [HttpPost("{id}/addProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Post(String id, [FromBody] PostAddProductRequest request)
        {
            PostAddCartResponse response = this.cartService.AddNewProduct(id, request.SkuId, request.Count);

            switch (response.StatusCode)
            {
                case StatusCodes.Status200OK:
                    return Ok(response.Cart);
                case StatusCodes.Status406NotAcceptable:
                    return StatusCode(StatusCodes.Status406NotAcceptable, response);
                case StatusCodes.Status404NotFound:
                    return NotFound(response);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // PUT api/<CartController>/updateProduct
        [HttpPut("{id}/updateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Put(String id, [FromBody] PutAddProductRequest request)
        {
            PutAddCartResponse response = this.cartService.UpdateProduct(id, request.SkuId, request.Count);

            switch (response.StatusCode)
            {
                case StatusCodes.Status200OK:
                    return Ok(response.Cart);
                case StatusCodes.Status406NotAcceptable:
                    return StatusCode(StatusCodes.Status406NotAcceptable, response);
                case StatusCodes.Status404NotFound:
                    return NotFound(response);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}/deleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Delete(String id, [FromBody] DeleteAddProductRequest request)
        {
            DeleteCartResponse response = this.cartService.DeleteProduct(id, request.SkuId);

            switch (response.StatusCode)
            {
                case StatusCodes.Status200OK:
                    return Ok(response.Cart);
                case StatusCodes.Status404NotFound:
                    return NotFound(response);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
