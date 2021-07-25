using FluentValidation;
using LicenseGeneratorApplication.Command.License;

namespace LicenseGenerator.Application.Validations
{
    public class LicenseCreateCommandValidation : AbstractValidator<LicenseCreateCommand>
    {
        public LicenseCreateCommandValidation()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("ProductId name is required");
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithMessage("CustomerId name is required");
            RuleFor(x => x.ExpireDate).NotNull().NotEmpty().WithMessage("ExpireDate name is required");
            RuleFor(x => x.Features).NotNull().NotEmpty().WithMessage("Features name is required");
        }
    }
}
