
namespace EmployeeChallenge.Xam.Validations
{
    using EmployeeChallenge.Xam.Model;
    using EmployeeChallenge.Xam.Validations;

    public static class EmployeeValidationExtensions
    {
        public static Employee ToNonValidatableObject(this EmployeeValidableObject employeeValidableObject)
        {
            return new Employee(employeeValidableObject.ID)
            {
                FirstName = employeeValidableObject.FirstName.Value,
                LastName = employeeValidableObject.LastName.Value,
                DateOfBirth = employeeValidableObject.DateOfBirth.Value,
                Email = employeeValidableObject.Email.Value,
                PhoneNumber = employeeValidableObject.PhoneNumber.Value,
                AddressLine = employeeValidableObject.AddressLine.Value,
                City = employeeValidableObject.City.Value,
                Country = employeeValidableObject.Country.Value,
                ZipCode = employeeValidableObject.ZipCode.Value
            };
        }
        public static EmployeeValidableObject ToValidatableObject(this Employee employee)
        {
            var employeeValidableObject = new EmployeeValidableObject(employee.ID);

            employeeValidableObject.FirstName.Value = employee.FirstName;
            employeeValidableObject.LastName.Value = employee.LastName;
            employeeValidableObject.DateOfBirth.Value = employee.DateOfBirth;
            employeeValidableObject.Email.Value = employee.Email;
            employeeValidableObject.PhoneNumber.Value = employee.PhoneNumber;
            employeeValidableObject.AddressLine.Value = employee.AddressLine;
            employeeValidableObject.City.Value = employee.City;
            employeeValidableObject.Country.Value = employee.Country;
            employeeValidableObject.ZipCode.Value = employee.ZipCode;

            return employeeValidableObject;
        }

    }
}
