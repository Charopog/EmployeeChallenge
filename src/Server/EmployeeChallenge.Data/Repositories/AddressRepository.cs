
namespace EmployeeChallenge.Data.Repositories
{
    using EmployeeChallenge.Data.Repositories.Abstractions;
    using EmployeeChallenge.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class AddressRepository : IAddressRepository
    {
        private readonly EmployeeChallengeContext _context;

        public AddressRepository(EmployeeChallengeContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public Task<Employee> GetEmployeeOfAdressOrDefaultAsync()
        {
            return _context.Addresses.Select(a => a.Employee).FirstOrDefaultAsync();
        }

    }
}
