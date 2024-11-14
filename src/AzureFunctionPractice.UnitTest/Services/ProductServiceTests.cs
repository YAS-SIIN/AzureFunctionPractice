using AzureFunctionPractice.Application.Services.Products;

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
        ProductService ProductService = new ProductService(_testTools.AppMemoryDbContext);

        var response = await ProductService.GetProductsAsync(CancellationToken.None);
        Assert.True(response.Any());
    }
    #endregion


}
