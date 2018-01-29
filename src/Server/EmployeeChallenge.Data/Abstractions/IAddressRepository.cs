using System.Threading.Tasks;
using EmployeeChallenge.Entities;

namespace EmployeeChallenge.Data.Repositories.Abstractions
{
    public interface IAddressRepository
    {
        Task<Employee> GetEmployeeOfAdressOrDefaultAsync();
    }
}