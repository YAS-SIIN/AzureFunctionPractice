

using AzureFunctionPractice.Application.Dtos.Product;

namespace AzureFunctionPractice.UnitTest.Services;

public class ProductServiceTests_Data
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
   public static IEnumerable<object[]> SetDataFor_CreateProduct_WithNameIsEmpty_ShouldBeFailed()
    {
        yield return new object[] { new ProductInputDto() {
            Name = "",
            Description = "TestProduct",
            Price = 15000
        }
    };
    }


}


