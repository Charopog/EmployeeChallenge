using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeChallenge.Entities;

namespace EmployeeChallenge.Data.Repositories.Abstractions
{
    public interface ISkillAssigmentRepository
    {
        void AddNewSkillToEmployee(Guid employeeID, Skill skill);
        void AddSkillToEmployee(Guid employeeID, Guid skillID);
        Task<bool> EmployeeHasSkillAsync(Guid employeeID, Guid skillID);
        Task<List<Skill>> GetEmployeeSkillsAsync(Guid employeeID);
        Task RemoveSkillFromEmployeeAsync(Guid employeeID, Guid skillID);
        Task<Skill> GetEmployeeSkillOrDefaultAsync(Guid employeeID, Guid skillID);
        Task CommitAsync();
    }
}