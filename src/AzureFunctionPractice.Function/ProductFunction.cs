using AzureFunctionPractice.Application.Dtos.Product;
using AzureFunctionPractice.Application.Services.Products;
using AzureFunctionPractice.Domain.DBContext;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace AzureFunctionPractice
{
    public class ProductFunction
    {
        private readonly ILogger<ProductFunction> _logger;
        private readonly IProductService _productService;
        private readonly IValidator<ProductInputDto> _validator;

        public ProductFunction(ILogger<ProductFunction> logger, IProductService productService, IValidator<ProductInputDto> validator)
        {
            _logger = logger;
            _productService = productService;
            _validator = validator;
        }

        [Function("ProductFunction")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req, CancellationToken cancellationToken)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
           
            string content = await new StreamReader(req.Body).ReadToEndAsync();
            if (req.Method == HttpMethod.Get.ToString())
            {
                var res = await _productService.GetProductsAsync(cancellationToken);
                return new OkObjectResult(res);
            }
            else if (req.Method == HttpMethod.Post.ToString())
            {
                var productInput = JsonSerializer.Deserialize<ProductInputDto>(content);
                if (productInput is ProductInputDto)
                {
                    var productValidationResult = await _validator.ValidateAsync(productInput);

                    if (!productValidationResult.IsValid)
                    {
                        return new BadRequestObjectResult(productValidationResult.Errors.Select(e => new
                        {
                            e.ErrorCode,
                            e.PropertyName,
                            e.ErrorMessage
                        }));
                    }
                    var res = await _productService.AddProductsAsync(productInput, cancellationToken);
                    return new OkObjectResult(res); 
                } else
                {
                    return new BadRequestObjectResult("Json format is wrong!");
                }
            }
            return new OkObjectResult(null);
        }

    }
}
