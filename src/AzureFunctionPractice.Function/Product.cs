using AzureFunctionPractice.Domain.DBContext;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctionPractice
{
    public class Product
    {
        private readonly ILogger<Product> _logger;

        public Product(ILogger<Product> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _appDBContext = appDBContext;
        }

        [Function("GetProducts")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        { 
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult(_appDBContext.Products.ToList());
        }

    }
}
