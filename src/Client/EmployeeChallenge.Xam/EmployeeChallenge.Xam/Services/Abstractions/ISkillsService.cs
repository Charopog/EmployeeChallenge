
namespace EmployeeChallenge.Xam.Services.Abstractions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeChallenge.Xam.Model;

    public interface ISkillsService
    {
        Task<IEnumerable<Skill>> GetAllSkillsAsync();
    }
}