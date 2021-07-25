using FluentValidation;
using LicenseGeneratorApplication.Command.Product;

namespace LicenseGenerator.Application.Validations
{
   public class ProductAddCommandValidation: AbstractValidator<ProductAddCommand>
    {
        public ProductAddCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Name is required");
        }
    }
}
