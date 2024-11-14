

using AzureFunctionPractice.Application.Dtos.Product;

namespace AzureFunctionPractice.UnitTest.Services;

public class ProjectServiceTests_Data
{
    public static IEnumerable<object[]> SetDataFor_CreateProduct_WithEverythingIsOk()
    {
        yield return new object[] { new ProductInputDto() {
            Name = "TestProduct",
            Description = "TestProduct",
            Price = 15000
        }
    };
    }
}
