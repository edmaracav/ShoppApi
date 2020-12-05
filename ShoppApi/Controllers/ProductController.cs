using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppApi.Model.Response;
using ShoppApi.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get()
        {
            GetProductResponse response = productService.GetAllProducts();

            switch (response.StatusCode)
            {
                case StatusCodes.Status200OK:
                    return Ok(response.Products);
                case StatusCodes.Status404NotFound:
                    return NotFound(response);
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

    }
}
