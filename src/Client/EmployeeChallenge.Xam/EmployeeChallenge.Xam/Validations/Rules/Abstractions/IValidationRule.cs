
namespace EmployeeChallenge.Xam.Validations.Rules.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IValidationRule<T>
    {
        string ValidationMessage { get; set; }
        bool Check(T value);
    }
    
}
