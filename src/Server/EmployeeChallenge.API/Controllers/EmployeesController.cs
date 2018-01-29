

namespace EmployeeChallenge.API.Controllers
{
    using System;
    using System.Threading.Tasks;
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Services.Abstractions;
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService ?? throw new ArgumentNullException(nameof(employeesService));

        }

        // GET: api/Employees
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employeeDtos = await _employeesService.GetAllEmployeesAsync();

            return new OkObjectResult(employeeDtos);
        }

        // GET: api/Employees/empoyeeGuid
        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<IActionResult> Get(Guid id)
        {
            
            var employee = await _employeesService.GetEmployeeAsync(id);

            return new OkObjectResult(employee);
        }
        

        // POST: api/Employees
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdEmployeeID = await _employeesService.CreateEmployeeAsync(employeeDto);
            employeeDto.ID = createdEmployeeID;

            var routevalues = new { controller = "Employees", id = createdEmployeeID };
            CreatedAtRouteResult result = CreatedAtRoute("GetEmployee", routevalues, employeeDto);

            return result;
        }

        // PUT: api/Employees/empoyeeGuid
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _employeesService.UpdateEmployeeAsync(id, employeeDto);

            return new NoContentResult();

        }

        // DELETE: api/Employees/empoyeeGuid
        [HttpDelete("{id}", Name = "RemoveEmployee")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _employeesService.DeleteEmployeeAsync(id);

            return new NoContentResult();

        }

        // GET: api/Employees/empoyeeGuid/skills
        [HttpGet("{id}/skills", Name = "GetEmployeeSkills")]
        public async Task<IActionResult> GetEmployeeSkills(Guid id)
        {

            var skills = await _employeesService.GetEmployeeSkillsAsync(id);

            return new OkObjectResult(skills);
        }

        // GET: api/Employees/empoyeeGuid/skills/skillGuid
        [HttpGet("{employeeID}/skills/{skillID}", Name = "GetEmployeeSkill")]
        public async Task<IActionResult> GetEmployeeSkill(Guid employeeID, Guid skillID)
        {

            var skill = await _employeesService.GetEmployeeSkillAsync(employeeID, skillID);

            return new OkObjectResult(skill);
        }

        // POST: api/Employees/empoyeeGuid/skills
        [HttpPost("{id}/skills",Name = "AddSkillToEmployee")]
        public async Task<IActionResult> AddSkillToEmployee(Guid id, [FromBody]SkillDto skillDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedSkillID = await _employeesService.AddSkillToEmployeeAsync(id,skillDto);
            skillDto.ID = addedSkillID;
            var routevalues = new { controller = "Employees", employeeID = id, skillID = addedSkillID };
            CreatedAtRouteResult result = CreatedAtRoute("GetEmployeeSkill", routevalues, skillDto);


            return result;

        }


        // DELETE: api/Employee/empoyeeGuid/skills/skillGuid
        [HttpDelete("{employeeID}/skills/{skillID}", Name = "RemoveEmployeeSkill")]
        public async Task<IActionResult> RemoveSkillFromEmployee(Guid employeeID, Guid skillID)
        {
            await _employeesService.RemoveSkillFromEmployeeAsync(employeeID, skillID);

            return new NoContentResult();

        }

    }
}
