using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ShoppApi.Model;
using ShoppApi.Model.Response;
using ShoppApi.Repositories.Contracts;
using ShoppApi.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppApi.Service
{
    public class ProductService : IProductService
    {
        private readonly ILogger logger;

        private readonly IProductRepository productRepository;

        public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
        {
            this.logger = logger;
            this.productRepository = productRepository;
        }

        public GetProductResponse GetAllProducts()
        {
            GetProductResponse response = new GetProductResponse();

            logger.LogInformation("CartService.GetAllProducts - Start.");

            List<Product> products = this.productRepository.GetAll();

            if (products == null)
            {
                response.ErrorMessage = "Nenhum produto encontrado.";
                response.StatusCode = StatusCodes.Status404NotFound;

                return response;
            }

            response.Products = products;
            response.StatusCode = StatusCodes.Status200OK;
            logger.LogInformation("CartService.GetAllProducts - End.");

            return response;
        }
    }
}
