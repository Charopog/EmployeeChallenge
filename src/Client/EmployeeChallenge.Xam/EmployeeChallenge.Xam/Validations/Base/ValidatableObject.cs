
namespace EmployeeChallenge.Xam.Validations.Base
{
    using EmployeeChallenge.Xam.Validations.Base.Abstractions;
    using EmployeeChallenge.Xam.Validations.Rules.Abstractions;
    using Prism.Mvvm;
    using System.Collections.Generic;
    using System.Linq;

    public class ValidatableObject<T> : BindableBase, IValidity
    {
        private readonly List<IValidationRule<T>> _validations;
        private List<string> _errors;
        private T _value;
        private bool _isValid;

        public List<IValidationRule<T>> Validations => _validations;

        public List<string> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                SetProperty(ref _errors,value);
            }
        }

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                
                SetProperty(ref _value, value);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }
            set
            {
                SetProperty(ref _isValid, value);
            }
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new List<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                .Select(v => v.ValidationMessage);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }
    }
}
