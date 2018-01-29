using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeChallenge.Entities;

namespace EmployeeChallenge.Data.Repositories.Abstractions
{
    public interface IEmployeeRepository
    {
        Task CommitAsync();
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<bool> ExistsAsync(Guid employeeID);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetSingleOrDefaultEmployeeAsync(Guid employeeID);
        void UpdateEmployee(Employee employee);
    }
}