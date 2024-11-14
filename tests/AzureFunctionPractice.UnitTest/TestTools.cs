

using AzureFunctionPractice.Domain.DBContext;
using AzureFunctionPractice.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace AzureFunctionPractice.UnitTest;

public class TestTools
{

    public AppDBContext AppMemoryDbContext;

    /// <summary>
    /// Initialization
    /// </summary>
    public void Initialize(string testClassName)
    {
        var dbContextOptionsBuilder = new DbContextOptionsBuilder<AppDBContext>();

        dbContextOptionsBuilder.UseInMemoryDatabase($"AppDBContext_{testClassName}");
        DbContextOptions<AppDBContext>? contextOptions = dbContextOptionsBuilder.Options;
        AppMemoryDbContext = new AppDBContext(contextOptions);
        SeedData();
    }

    /// <summary>
    /// Initializing new data
    /// </summary>
    public void SeedData()
    {
        List<Product> customerList = new List<Product>();
      
        if (!AppMemoryDbContext.Products.Any())
        { 
            for (int i = 1; i <= 3; i++)
            {
                customerList.Add(new Product
                { 
                    Name = $"TestName{i}", 
                    Description = $"TestName{i}", 
                    Price = i * 1000
                });
            }

            AppMemoryDbContext.Products.AddRange(customerList);
        }
         
        AppMemoryDbContext.SaveChanges();
        
    }

}
