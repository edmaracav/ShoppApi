using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Controllers
{
    [ApiController]
    [Route("[product]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return null;
        }

        [HttpPost]
        public IEnumerable<Product> Post()
        {
            return null;
        }

        [HttpPut]
        public IEnumerable<Product> Put()
        {
            return null;
        }

        [HttpDelete]
        public IEnumerable<Product> Delete()
        {
            return null;
        }
    }
}
