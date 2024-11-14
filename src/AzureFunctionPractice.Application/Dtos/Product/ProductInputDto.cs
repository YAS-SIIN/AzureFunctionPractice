


using FluentValidation;

namespace AzureFunctionPractice.Application.Dtos.Product;

public class ProductInputDto : BaseDto
{
  
    public string Name { get; set; }
    public decimal Price { get; set; }
}


public class ProductInputDtoValidator : AbstractValidator<ProductInputDto>
{
    public ProductInputDtoValidator()
    {

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Enter {PropertyName}.")
            .MaximumLength(100).WithMessage("Maximum size of {PropertyName} is {MaxLength}.")
            .MinimumLength(3).WithMessage("Minimum size of {PropertyName} is {MinLength}.");
         
        RuleFor(x => x.Price).NotEmpty().WithMessage("Enter {PropertyName}.");
    }

}