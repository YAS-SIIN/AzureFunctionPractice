
using AzureFunctionPractice.Domain.DBContext;
using AzureFunctionPractice.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System.Data;
using System.Diagnostics;
using System.Text;

namespace AzureFunctionPractice.Function;

public class DataGenerator
{
    /// <summary>
    /// Initializing new data
    /// </summary>
    /// <param name="serviceProvider"></param>
    public static void SeedData(IServiceProvider serviceProvider)
    {
        var _dbContext = serviceProvider.GetRequiredService<AppDBContext>();
        // Add new customer
        if (!_dbContext.Products.Any())
        {
            List<Product> products = new() {
              new Product {  Name = "Test1", Description = "Test1", Price = 10001 },
              new Product {  Name = "Test2", Description = "Test2", Price = 10002 },
              new Product {  Name = "Test3", Description = "Test3", Price = 10003 },
        };
            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
        }

    }
}
