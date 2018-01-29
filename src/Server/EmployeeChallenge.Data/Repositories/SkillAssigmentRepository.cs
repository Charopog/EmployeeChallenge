
namespace EmployeeChallenge.Data.Repositories
{
    using EmployeeChallenge.Data.Repositories.Abstractions;
    using EmployeeChallenge.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SkillAssigmentRepository : ISkillAssigmentRepository
    {

        private readonly EmployeeChallengeContext _context;

        public SkillAssigmentRepository(EmployeeChallengeContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Task<List<Skill>> GetEmployeeSkillsAsync(Guid employeeID)
        {
            return _context.SkillAssignments.Where(sa => sa.EmployeeID == employeeID)
                                        .Select(sa => sa.Skill)
                                        .AsNoTracking()
                                        .ToListAsync();
        }

        public Task<Skill> GetEmployeeSkillOrDefaultAsync(Guid employeeID, Guid skillID)
        {
            return _context.SkillAssignments
                                        .Where(sa => sa.EmployeeID == employeeID && sa.SkillID == skillID)
                                        .Select(sa => sa.Skill)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync();
        }

        public void AddNewSkillToEmployee(Guid employeeID, Skill skill)
        {
            var skillAssignment = new SkillAssignment()
            {
                EmployeeID = employeeID,
                Skill = skill
            };

            _context.Add<SkillAssignment>(skillAssignment);

        }

        public void AddSkillToEmployee(Guid employeeID, Guid skillID)
        {
            var skillAssignment = new SkillAssignment()
            {
                EmployeeID = employeeID,
                SkillID = skillID
            };

            _context.Add<SkillAssignment>(skillAssignment);

        }

        public async Task RemoveSkillFromEmployeeAsync(Guid employeeID, Guid skillID)
        {
            var skillAssignment = await _context.SkillAssignments
                                                        .Where(sa => sa.EmployeeID == employeeID && sa.SkillID == skillID)
                                                        .FirstOrDefaultAsync();

            _context.Remove<SkillAssignment>(skillAssignment);
        }

        public Task<bool> EmployeeHasSkillAsync(Guid employeeID, Guid skillID)
        {
            return _context.SkillAssignments.AnyAsync(sa => sa.EmployeeID == employeeID && sa.SkillID == skillID);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
