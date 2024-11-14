

using AzureFunctionPractice.Application.Dtos.Product;
using AzureFunctionPractice.Domain.Entities;

namespace AzureFunctionPractice.Application.Services.Products;

public interface IProductService
{
    Task<List<ProductOutputDto>> GetProductsAsync(CancellationToken cancellationToken = default);
    Task<ProductOutputDto> AddProductsAsync(ProductInputDto productInputDto, CancellationToken cancellationToken = default);
}
