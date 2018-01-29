
namespace EmployeeChallenge.Xam.Validations.Rules
{
    using EmployeeChallenge.Xam.Validations.Rules.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IsNumericValueRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;

            return int.TryParse(str, out int num);
        }
    }
}
