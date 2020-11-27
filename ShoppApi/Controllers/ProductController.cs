using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public IEnumerable<WeatherForecast> Get()
        {
            return null;
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> Post()
        {
            return null;
        }

        [HttpPut]
        public IEnumerable<WeatherForecast> Put()
        {
            return null;
        }

        [HttpDelete]
        public IEnumerable<WeatherForecast> Delete()
        {
            return null;
        }
    }
}
