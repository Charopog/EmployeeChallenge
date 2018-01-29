
namespace EmployeeChallenge.Dtos.Validations
{
    using FluentValidation;

    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        { 
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("FirstName cannot be empty");
            RuleFor(e => e.FirstName).MaximumLength(100).WithMessage("FirstName cannot be more than 100 characters");

            RuleFor(e => e.LastName).NotEmpty().WithMessage("LastName cannot be empty");
            RuleFor(e => e.LastName).MaximumLength(100).WithMessage("LastName cannot be more than 100 characters");

            RuleFor(e => e.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(e => e.Email).MaximumLength(100).WithMessage("Email cannot be more than 100 characters");

            RuleFor(e => e.AddressLine).NotEmpty().WithMessage("AddressLine cannot be empty");
            RuleFor(e => e.AddressLine).MaximumLength(100).WithMessage("AddressLine cannot be more than 100 characters");

            RuleFor(e => e.City).NotEmpty().WithMessage("City cannot be empty");
            RuleFor(e => e.City).MaximumLength(100).WithMessage("City cannot be more than 100 characters");

            RuleFor(e => e.Country).NotEmpty().WithMessage("Country cannot be empty");
            RuleFor(e => e.Country).MaximumLength(100).WithMessage("Country cannot be more than 100 characters");

            RuleFor(e => e.ZipCode).MaximumLength(50).WithMessage("ZipCode cannot be more than 50 characters");
        }
    }
}
