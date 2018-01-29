
namespace EmployeeChallenge.Data.Repositories
{
    using EmployeeChallenge.Data.Repositories.Abstractions;
    using EmployeeChallenge.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SkillRepository : ISkillRepository
    {
        private readonly EmployeeChallengeContext _context;

        public SkillRepository(EmployeeChallengeContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<Skill> GetSingleOrDefaultSkillAsync(Guid skillID)
        {
            return _context.Skills.AsNoTracking()
                                 .FirstOrDefaultAsync(s => s.ID == skillID);
        }

        public Task<List<Skill>> GetAllSkillsAsync()
        {
            return _context.Skills.AsNoTracking()
                                 .ToListAsync();
        }

        public void CreateSkill(Skill skill)
        {
            _context.Add<Skill>(skill);
        }

        public void UpdateSkill(Skill skill)
        {
            _context.Update<Skill>(skill);
        }

        public void DeleteSkill(Skill skill)
        {
            _context.Remove<Skill>(skill);
        }

        public Task<bool> ExistsAsync(Guid skillID)
        {
            return _context.Skills.AnyAsync(s => s.ID == skillID);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
