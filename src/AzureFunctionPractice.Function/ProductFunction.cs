using AzureFunctionPractice.Application.Dtos.Product;
using AzureFunctionPractice.Application.Services.Products;
using AzureFunctionPractice.Domain.DBContext;
using System.Text.Json;
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

        [Function("ProductFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req, CancellationToken cancellationToken)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
           
            string content = await new StreamReader(req.Body).ReadToEndAsync();
            if (string.Equals(req.Method, "get", StringComparison.CurrentCultureIgnoreCase))
            {
                var res = await _productService.GetProductsAsync(cancellationToken);
                return new OkObjectResult(res);
            }
            else if (string.Equals(req.Method, "post", StringComparison.CurrentCultureIgnoreCase))
            {
                var productInput = JsonSerializer.Deserialize<ProductInputDto>(content);
                if (productInput is ProductInputDto)
                {
                    var res = await _productService.AddProductsAsync(productInput, cancellationToken);
                    return new OkObjectResult(res); 
                }

            }
            return new OkObjectResult(null);
        }

    }
}
