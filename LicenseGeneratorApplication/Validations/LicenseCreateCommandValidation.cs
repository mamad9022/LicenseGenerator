using FluentValidation;
using LicenseGenerator.Application.Command.License;

namespace LicenseGenerator.Application.Validations
{
    public class LicenseCreateCommandValidation : AbstractValidator<LicenseCreateCommand>
    {
        public LicenseCreateCommandValidation()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("ProductId name is required");
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithMessage("CustomerId name is required");
        }
    }
}
