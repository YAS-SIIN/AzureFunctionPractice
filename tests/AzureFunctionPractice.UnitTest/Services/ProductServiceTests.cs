using AzureFunctionPractice.Application.Dtos.Product;
using AzureFunctionPractice.Application.Services.Products;

using Microsoft.Extensions.Logging;

using System.Xml.Linq;

namespace AzureFunctionPractice.UnitTest.Services;

public class ProductServiceTests
{
    private readonly TestTools _testTools;
    public ProductServiceTests()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(ProductServiceTests));
    }


    #region GetProducts
    [Fact]
    public async Task GetProducts_ShouldHasData()
    { 
        ProductService productService = new ProductService(_testTools.AppMemoryDbContext);

        var response = await productService.GetProductsAsync(CancellationToken.None);
        Assert.True(response.Any());
    }
    #endregion


    #region CreateProject
    [Theory]
    [MemberData(nameof(ProjectServiceTests_Data.SetDataFor_CreateProduct_WithEverythingIsOk), MemberType = typeof(ProjectServiceTests_Data))]
    public async Task CreateProduct_WhenEverythingIsOk_ShouldBeSucceeded(ProductInputDto productInputDto)
    { 
        ProductService productService = new ProductService(_testTools.AppMemoryDbContext);
         
        var response = await productService.AddProductsAsync(productInputDto, CancellationToken.None);

        Assert.NotNull(response);
        Assert.NotNull(response.Id);

        var createdRow = await _testTools.AppMemoryDbContext.Products.FindAsync(response.Id);
        Assert.NotNull(createdRow);

        Assert.Equal(productInputDto.Name, createdRow.Name);
        Assert.Equal(productInputDto.Price, createdRow.Price);
        Assert.Equal(productInputDto.Description, createdRow.Description); 
    }
     
    #endregion

}
