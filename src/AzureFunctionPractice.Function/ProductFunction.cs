using AzureFunctionPractice.Application.Services.Products;
using AzureFunctionPractice.Domain.DBContext;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionPractice
{
    public class ProductFunction
    {
        private readonly ILogger<ProductFunction> _logger;
        private readonly IProductService _productService;

        public ProductFunction(ILogger<ProductFunction> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [Function("GetProducts")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        { 
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var res = await _productService.GetProductsAsync();
            return new OkObjectResult(res);
        }

    }
}
