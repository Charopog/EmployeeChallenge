
namespace EmployeeChallenge.Services.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Entities;

    public interface IEmployeesService
    {
        Task<Guid> AddSkillToEmployeeAsync(Guid employeeID, SkillDto skillDto);
        Task<Guid> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(Guid employeeID);
        Task<bool> EmployeeExistsAsync(Guid employeeID);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeAsync(Guid employeeID);
        Task<IEnumerable<SkillDto>> GetEmployeeSkillsAsync(Guid employeeID);
        Task<SkillDto> GetEmployeeSkillAsync(Guid employeeID, Guid skillID);
        Task RemoveSkillFromEmployeeAsync(Guid employeeID, Guid skillID);
        Task UpdateEmployeeAsync(Guid employeeID, EmployeeDto employeeDto);
    }
}