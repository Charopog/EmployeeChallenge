
namespace EmployeeChallenge.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Services.Abstractions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class SkillsController : Controller
    {
        private readonly ISkillsService _skillsService;

        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService ?? throw new ArgumentNullException(nameof(skillsService));
        }

        // GET: api/Skills
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var skillsDtos = await _skillsService.GetAllSkillsAsync();

            return new OkObjectResult(skillsDtos);
        }

        // GET: api/Skills/skillGuid
        [HttpGet("{id}", Name = "GetSkill")]
        public async Task<IActionResult> Get(Guid id)
        {
            var skillDto = await _skillsService.GetSkillAsync(id);

            return new OkObjectResult(skillDto);
        }
        
        // POST: api/Skills
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SkillDto skillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdSkillID = await _skillsService.CreateSkillAsync(skillDto);
            skillDto.ID = createdSkillID;

            var routevalues = new { controller = "Skills", id = createdSkillID };
            CreatedAtRouteResult result = CreatedAtRoute("GetSkill", routevalues, skillDto);

            return result;
        }

        // PUT: api/Skills/skillGuid
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]SkillDto skillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _skillsService.UpdateSkillAsync(id, skillDto);

            return new NoContentResult();
        }

        // DELETE: api/Skills/skillGuid
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _skillsService.DeleteSkillAsync(id);

            return new NoContentResult();
        }
    }
}
