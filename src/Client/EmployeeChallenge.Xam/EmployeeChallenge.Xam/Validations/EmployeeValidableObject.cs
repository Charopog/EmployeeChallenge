
namespace EmployeeChallenge.Xam.Validations
{
    using EmployeeChallenge.Xam.Validations.Base;
    using EmployeeChallenge.Xam.Validations.Rules;
    using System;

    public class EmployeeValidableObject
    {
        public EmployeeValidableObject(Guid id)
        {
            ID = id;
            FirstName = new ValidatableObject<string>();
            LastName = new ValidatableObject<string>();
            DateOfBirth = new ValidatableObject<DateTime>();
            Email = new ValidatableObject<string>();
            PhoneNumber = new ValidatableObject<string>();
            AddressLine = new ValidatableObject<string>();
            AddressLine = new ValidatableObject<string>();
            City = new ValidatableObject<string>();
            Country = new ValidatableObject<string>();
            ZipCode = new ValidatableObject<string>();

            this.AddValidations();
        }

        public Guid ID { get; private set; }

        public ValidatableObject<string> FirstName { get; private set; }
        
        public ValidatableObject<string> LastName { get; private set; }
        
        public ValidatableObject<DateTime> DateOfBirth { get; private set; }
        
        public ValidatableObject<string> Email { get; private set; }
        
        public ValidatableObject<string> PhoneNumber { get; private set; }

        public ValidatableObject<string> AddressLine { get; private set; }

        public ValidatableObject<string> City { get; private set; }

        public ValidatableObject<string> Country { get; private set; }

        public ValidatableObject<string> ZipCode { get; private set; }


        public bool IsValid()
        {
            return FirstName.Validate() &&
                LastName.Validate() &&
                Email.Validate() &&
                AddressLine.Validate() &&
                City.Validate() &&
                Country.Validate();

        }

        private void AddValidations()
        {
            FirstName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "First Name is required" });
            FirstName.Validations.Add(new IsLengthValidRule<string>(0, 50) { ValidationMessage = $"First Name cannot be more than {50} Characters" });

            LastName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Last Name is required" });
            LastName.Validations.Add(new IsLengthValidRule<string>(0, 50) { ValidationMessage = $"Last Name cannot be more than {50} Characters" });

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Email is required" });
            Email.Validations.Add(new IsLengthValidRule<string>(0, 50) { ValidationMessage = $"Email cannot be more than {50} Characters" });

            AddressLine.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Address Line is required" });
            AddressLine.Validations.Add(new IsLengthValidRule<string>(0, 50) { ValidationMessage = $"Address Line cannot must be more than {50} Characters" });

            City.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "City is required" });
            City.Validations.Add(new IsLengthValidRule<string>(0, 50) { ValidationMessage = $"City cannot be more than {50} Characters" });

            Country.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Country is required" });
            Country.Validations.Add(new IsLengthValidRule<string>(0, 50) { ValidationMessage = $"Country cannot be more than {50} Characters" });


        }
    }
}
