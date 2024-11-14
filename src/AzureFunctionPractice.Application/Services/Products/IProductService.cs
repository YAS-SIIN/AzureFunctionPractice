

using AzureFunctionPractice.Application.Dtos.Product;
using AzureFunctionPractice.Domain.Entities;

namespace AzureFunctionPractice.Application.Services.Products;

public interface IProductService
{
    Task<List<ProductOutputDto>> GetProducts(ProductInputDto productInput);
}
