using AzureFunctionPractice.Application.Dtos.Product;
using AzureFunctionPractice.Application.Services.Products;

using FluentValidation;

using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.Common;

using System.Xml.Linq;

namespace AzureFunctionPractice.UnitTest.Services;

public class ProductServiceTests
{
    private readonly TestTools _testTools;
    private readonly ProductInputDtoValidator _validationRules;
    public ProductServiceTests()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(ProductServiceTests));
        _validationRules = new ProductInputDtoValidator();
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


    #region CreateProduct
    [Theory]
    [MemberData(nameof(ProductServiceTests_Data.SetDataFor_CreateProduct_WithEverythingIsOk), MemberType = typeof(ProductServiceTests_Data))]
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

    [Theory]
    [MemberData(nameof(ProductServiceTests_Data.SetDataFor_CreateProduct_WithNameIsEmpty_ShouldBeFailed), MemberType = typeof(ProductServiceTests_Data))]
    public async Task CreateProduct_WhenNameIsEmpty_ShouldBeFailed(ProductInputDto productInputDto)
    {

        ProductService productService = new ProductService(_testTools.AppMemoryDbContext);

        var response = await productService.AddProductsAsync(productInputDto, CancellationToken.None);

        Assert.True(string.IsNullOrWhiteSpace(productInputDto.Name));
        var validation = await _validationRules.ValidateAsync(productInputDto);
        Assert.False(validation.IsValid);
    }
    
    #endregion

}
