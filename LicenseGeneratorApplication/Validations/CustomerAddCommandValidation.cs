using FluentValidation;
using LicenseGenerator.Application.Command.Customer;

namespace LicenseGenerator.Application.Validations
{
  public  class CustomerAddCommandValidation: AbstractValidator<CustomerAddCommand>
    {
        public CustomerAddCommandValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("First name is required");
        }
    }
}
