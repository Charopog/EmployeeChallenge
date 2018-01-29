using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeChallenge.Entities;

namespace EmployeeChallenge.Data.Repositories.Abstractions
{
    public interface ISkillRepository
    {
        Task CommitAsync();
        void CreateSkill(Skill skill);
        void DeleteSkill(Skill skill);
        Task<bool> ExistsAsync(Guid skillID);
        Task<List<Skill>> GetAllSkillsAsync();
        Task<Skill> GetSingleOrDefaultSkillAsync(Guid skillID);
        void UpdateSkill(Skill skill);
    }
}