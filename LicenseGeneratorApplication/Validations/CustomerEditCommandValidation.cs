using FluentValidation;
using LicenseGeneratorApplication.Command.Customer;

namespace LicenseGenerator.Application.Validations
{
  public  class CustomerEditCommandValidation: AbstractValidator<CustomerEditCommand>
    {
        public CustomerEditCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id is required");
        }
    }
}
