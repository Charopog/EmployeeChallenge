
namespace EmployeeChallenge.Xam.Mappings
{
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Xam.Model;

    public static class EmployeeMappings
    {
        public static Employee ToLocal(this EmployeeDto employeeDto)
        {
            return new Employee(employeeDto.ID)
            {
                AddressLine = employeeDto.AddressLine,
                City = employeeDto.City,
                Country = employeeDto.Country,
                DateOfBirth = employeeDto.DateOfBirth,
                Email = employeeDto.Email,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                PhoneNumber = employeeDto.PhoneNumber,
                ZipCode = employeeDto.ZipCode
            };
        }

        public static EmployeeDto ToDto(this Employee employee)
        {
            return new EmployeeDto()
            {
                ID = employee.ID,
                AddressLine = employee.AddressLine,
                City = employee.City,
                Country = employee.Country,
                DateOfBirth = employee.DateOfBirth,
                Email = employee.Email,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                ZipCode = employee.ZipCode
            };
        }
    }
}
