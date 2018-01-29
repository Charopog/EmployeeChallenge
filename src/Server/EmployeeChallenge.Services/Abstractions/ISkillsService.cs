using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeChallenge.Dtos;

namespace EmployeeChallenge.Services.Abstractions
{
    public interface ISkillsService
    {
        Task<Guid> CreateSkillAsync(SkillDto roleDto);
        Task DeleteSkillAsync(Guid skillID);
        Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
        Task<SkillDto> GetSkillAsync(Guid skillID);
        Task<bool> SkillExistsAsync(Guid skillID);
        Task UpdateSkillAsync(Guid skillID, SkillDto skillDto);
    }
}