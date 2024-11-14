 
namespace AzureFunctionPractice.UnitTest.Services;

public class ProductServiceTests
{
    private readonly TestTools _testTools;
    public ProductServiceTests()
    {
        _testTools = new TestTools();
        _testTools.Initialize(nameof(ProductServiceTests));
    }
}
