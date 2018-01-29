
namespace EmployeeChallenge.Xam.Services
{
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Xam.Model;
    using EmployeeChallenge.Xam.Utils.Factories.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Net;
    using System.Threading.Tasks;
    using EmployeeChallenge.Xam.Utils.Extensions;
    using EmployeeChallenge.Xam.Mappings;
    using System.Linq;
    using EmployeeChallenge.Xam.Services.Abstractions;

    public class SkillsService : ISkillsService
    {
        private readonly HttpClient _httpClient;

        public SkillsService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.GetOrCreateHttpClient(App.HttpClientBaseAddress);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            IEnumerable<SkillDto> skillsDtos =  new List<SkillDto>();
            var response = await _httpClient.GetAsync("api/skills").ConfigureAwait(false);
            if(response.IsSuccessStatusCode)
            {
                skillsDtos = await response.Content.ReadAsJsonAsync<IEnumerable<SkillDto>>().ConfigureAwait(false);
            }

            return skillsDtos.Select(s => s.ToLocal());

        }
    }
}
