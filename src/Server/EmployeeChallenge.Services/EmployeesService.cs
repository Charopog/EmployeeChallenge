
namespace EmployeeChallenge.Services
{
    using AutoMapper;
    using EmployeeChallenge.Common.CustomExceptions;
    using EmployeeChallenge.Data.Repositories.Abstractions;
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Entities;
    using EmployeeChallenge.Services.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EmployeesService : IEmployeesService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ISkillAssigmentRepository _skillAssigmentRepository;
        private readonly ISkillRepository _skillRepository;

        public EmployeesService(IMapper mapper, IEmployeeRepository employeeRepository, 
                                ISkillAssigmentRepository skillAssigmentRepository, ISkillRepository skillRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _skillAssigmentRepository = skillAssigmentRepository ?? throw new ArgumentNullException(nameof(skillAssigmentRepository));
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid employeeID)
        {
            var employee =  await _employeeRepository.GetSingleOrDefaultEmployeeAsync(employeeID);
            if(employee ==  null)
            {
                throw new CustomNotFoundException($"Employee {employeeID} does not exist");
            }

            return _mapper.Map<Employee, EmployeeDto>(employee);
        }

        public async Task<Guid> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<EmployeeDto, Employee>(employeeDto);

            _employeeRepository.CreateEmployee(employee);

            await _employeeRepository.CommitAsync();
            return employee.ID;

        }
        
        public async Task DeleteEmployeeAsync(Guid employeeID)
        {
            var employee = await _employeeRepository.GetSingleOrDefaultEmployeeAsync(employeeID);
            if (employee == null)
            {
                throw new CustomNotFoundException($"Employee {employeeID} does not exist");
            }

            _employeeRepository.DeleteEmployee(employee);

            await _employeeRepository.CommitAsync();
        }

        public async Task UpdateEmployeeAsync(Guid employeeID, EmployeeDto employeeDto)
        {
            var exists = await _employeeRepository.ExistsAsync(employeeID);
            if(!exists)
            {
                throw new CustomNotFoundException($"Employee {employeeDto.ID} does not exist");
            }
            employeeDto.ID = employeeID;
            var employee = _mapper.Map<EmployeeDto, Employee>(employeeDto);

            _employeeRepository.UpdateEmployee(employee);
            await _employeeRepository.CommitAsync();
        }

        public async Task<Guid> AddSkillToEmployeeAsync(Guid employeeID, SkillDto skillDto)
        {
            var isSkillAssigned = await _skillAssigmentRepository.EmployeeHasSkillAsync(employeeID, skillDto.ID);
            if (isSkillAssigned)
            {
                throw new CustomEntryExistsException($"Skill {skillDto.ID} is already assigned to Employee {employeeID}");
            }

            var employeeExists = await _employeeRepository.ExistsAsync(employeeID);
            if (!employeeExists)
            {
                throw new CustomNotFoundException($"Employee {employeeID} does not exist");
            }

            var skill = await _skillRepository.GetSingleOrDefaultSkillAsync(skillDto.ID);
            if (skill == null)
            {
                skill = _mapper.Map<SkillDto, Skill>(skillDto);
                _skillAssigmentRepository.AddNewSkillToEmployee(employeeID, skill);
            }
            else
            {
                _skillAssigmentRepository.AddSkillToEmployee(employeeID, skillDto.ID);
            }

            await _skillAssigmentRepository.CommitAsync();
            return skill.ID;
        }

        public async Task RemoveSkillFromEmployeeAsync(Guid employeeID, Guid skillID)
        {
            var isSkillAssigned = await _skillAssigmentRepository.EmployeeHasSkillAsync(employeeID, skillID);
            if (!isSkillAssigned)
            {
                throw new CustomEntryExistsException($"Skill {skillID} is not assigned to Employee {employeeID}");
            }
            await _skillAssigmentRepository.RemoveSkillFromEmployeeAsync(employeeID, skillID);

            await _skillAssigmentRepository.CommitAsync();

        }

        public async Task<IEnumerable<SkillDto>> GetEmployeeSkillsAsync(Guid employeeID)
        {
            var employeeExists = await _employeeRepository.ExistsAsync(employeeID);
            if (!employeeExists)
            {
                throw new CustomNotFoundException($"Employee {employeeID} does not exist");
            }

            var skills = await _skillAssigmentRepository.GetEmployeeSkillsAsync(employeeID);

            return _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDto>>(skills);

        }
        public async Task<SkillDto> GetEmployeeSkillAsync(Guid employeeID, Guid skillID)
        {
            var employeeHasSkill = await _skillAssigmentRepository.EmployeeHasSkillAsync(employeeID,skillID);
            if (!employeeHasSkill)
            {
                throw new CustomNotFoundException($"Employee {employeeID} does not have skill {skillID}");
            }

            var skill = await _skillAssigmentRepository.GetEmployeeSkillOrDefaultAsync(employeeID,skillID);

            return _mapper.Map<Skill, SkillDto>(skill);

        }
        public Task<bool> EmployeeExistsAsync(Guid employeeID)
        {
            return _employeeRepository.ExistsAsync(employeeID);
        }



    }
}
