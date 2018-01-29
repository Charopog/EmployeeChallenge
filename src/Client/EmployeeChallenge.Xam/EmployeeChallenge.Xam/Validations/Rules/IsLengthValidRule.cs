
namespace EmployeeChallenge.Xam.Validations.Rules
{
    using EmployeeChallenge.Xam.Validations.Rules.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class IsLengthValidRule<T> : IValidationRule<T>
    {
        private int _minLength;
        private int _maxLength;
        public IsLengthValidRule(int minLength, int maxLength)
        {
            if(maxLength<minLength)
            {
                throw new InvalidOperationException("maxLength cannot be less than minLength");
            }
            _minLength = minLength;
            _maxLength = maxLength;

        }
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value as string;

            return str.Length <= _maxLength && str.Length>=_minLength;
        }
    }
}
