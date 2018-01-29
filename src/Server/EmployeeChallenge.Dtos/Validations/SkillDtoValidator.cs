
namespace EmployeeChallenge.Dtos.Validations
{
    using FluentValidation;

    public class SkillDtoValidator : AbstractValidator<SkillDto>
    {
        public SkillDtoValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(r => r.Name).MaximumLength(100).WithMessage("Name cannot be more than 100 characters");

        }
    }
}
