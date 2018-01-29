
namespace EmployeeChallenge.Xam.Services.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeChallenge.Xam.Model;

    public interface IEmployeesService
    {
        Task<Guid> AddSkillToEmployeeAsync(Guid employeeID, Skill skill);
        Task<Guid> CreateNewEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(Guid employeeID);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<IEnumerable<Skill>> GetEmployeeSkillsAsync(Guid employeeID);
        Task RemoveSkillFromEmployeeAsync(Guid employeeID, Guid skillID);
        Task UpdateEmployeeAsync(Guid employeeID, Employee employee);
    }
}