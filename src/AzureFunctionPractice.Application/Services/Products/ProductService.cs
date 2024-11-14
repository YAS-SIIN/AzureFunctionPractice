

using AzureFunctionPractice.Application.Dtos.Product;
using AzureFunctionPractice.Domain.DBContext;
using AzureFunctionPractice.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace AzureFunctionPractice.Application.Services.Products;

public class ProductService : IProductService
{
    private readonly AppDBContext _appDBContext;
    public ProductService(AppDBContext appDBContext)
    {
        _appDBContext = appDBContext;
    }

    public async Task<List<ProductOutputDto>> GetProductsAsync(CancellationToken cancellationToken = default)
    {
        var res = await _appDBContext.Products.Select(a=> new ProductOutputDto
        {
            Description = a.Description,
            Id = a.Id,
            Name = a.Name,
            Price = a.Price,
        }).ToListAsync(cancellationToken);
        return res;
    }
}
