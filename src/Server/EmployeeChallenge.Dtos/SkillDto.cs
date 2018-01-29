
namespace EmployeeChallenge.Dtos
{
    using EmployeeChallenge.Dtos.Validations;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class SkillDto : IValidatableObject
    {

        public Guid ID { get; set; }
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new SkillDtoValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(item => new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}
