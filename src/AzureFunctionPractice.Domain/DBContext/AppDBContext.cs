using Microsoft.EntityFrameworkCore;

namespace AzureFunctionPractice.Domain.DBContext;

public class AppDBContext : DbContext
{
    public AppDBContext()
    {
        
    }

    public DbSet<Product> Products { get; set; } 

}
