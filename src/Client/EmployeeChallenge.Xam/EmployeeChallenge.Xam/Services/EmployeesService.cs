
namespace EmployeeChallenge.Xam.Services
{
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Xam.Mappings;
    using EmployeeChallenge.Xam.Model;
    using EmployeeChallenge.Xam.Services.Abstractions;
    using EmployeeChallenge.Xam.Utils.Extensions;
    using EmployeeChallenge.Xam.Utils.Factories.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    public class EmployeesService : IEmployeesService
    {
        private readonly HttpClient _httpClient;

        public EmployeesService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.GetOrCreateHttpClient(App.HttpClientBaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            IEnumerable<EmployeeDto> employeesDtos = new List<EmployeeDto>();
            var response = await _httpClient.GetAsync("api/employees").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            
            employeesDtos = await response.Content.ReadAsJsonAsync<IEnumerable<EmployeeDto>>().ConfigureAwait(false);
            
            var employees = employeesDtos.Select(e => e.ToLocal());

            return employees;
        }

        public async Task<Guid> CreateNewEmployeeAsync(Employee employee)
        {
            var employeeDto = employee.ToDto();

            var response = await _httpClient.PostAsJsonAsync($"api/employees", employeeDto).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();


            var createdEmployee = await response.Content.ReadAsJsonAsync<EmployeeDto>().ConfigureAwait(false);

            return createdEmployee.ID;
            
        }

        public async Task UpdateEmployeeAsync(Guid employeeID, Employee employee)
        {
            var employeeDto = employee.ToDto();

            var response = await _httpClient.PutAsJsonAsync($"api/employees/{employeeID}", employeeDto).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

        }

        public async Task DeleteEmployeeAsync(Guid employeeID)
        {
            var response = await _httpClient.DeleteAsync($"api/employees/{employeeID}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }


        public async Task<IEnumerable<Skill>> GetEmployeeSkillsAsync(Guid employeeID)
        {
            IEnumerable<SkillDto> employeeskillsDtos = new List<SkillDto>();
            var response = await _httpClient.GetAsync($"api/employees/{employeeID}/skills").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            employeeskillsDtos = await response.Content.ReadAsJsonAsync<IEnumerable<SkillDto>>().ConfigureAwait(false);

            var employeeskills = employeeskillsDtos.Select(e => e.ToLocal());

            return employeeskills;
        }

        public async Task<Guid> AddSkillToEmployeeAsync(Guid employeeID, Skill skill)
        {
            var skillDto = skill.ToDto();

            var response = await _httpClient.PostAsJsonAsync($"api/employees/{employeeID}/skills", skillDto).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();


            var createdSkill = await response.Content.ReadAsJsonAsync<SkillDto>().ConfigureAwait(false);

            return createdSkill.ID;

        }

        public async Task RemoveSkillFromEmployeeAsync(Guid employeeID, Guid skillID)
        {
            var response = await _httpClient.DeleteAsync($"api/employees/{employeeID}/skills/{skillID}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }
    }
}
