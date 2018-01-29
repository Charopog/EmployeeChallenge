
namespace EmployeeChallenge.Data.Repositories
{
    using EmployeeChallenge.Data.Repositories.Abstractions;
    using EmployeeChallenge.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeChallengeContext _context;

        public EmployeeRepository(EmployeeChallengeContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Task<Employee> GetSingleOrDefaultEmployeeAsync(Guid employeeID)
        {
            return _context.Employees.AsNoTracking()
                                    .Include(e => e.Address)
                                    .FirstOrDefaultAsync(e => e.ID == employeeID);
        }

        public Task<List<Employee>> GetAllEmployeesAsync()
        {
            return _context.Employees.AsNoTracking()
                                    .Include(e => e.Address)
                                    .ToListAsync();
        }

        public void CreateEmployee(Employee employee)
        {
            _context.Add<Employee>(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Update<Employee>(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Remove<Employee>(employee);
        }

        public Task<bool> ExistsAsync(Guid employeeID)
        {
            return _context.Employees.AnyAsync(e => e.ID == employeeID);
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
