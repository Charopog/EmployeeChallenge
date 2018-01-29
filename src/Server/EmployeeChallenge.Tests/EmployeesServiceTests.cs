
namespace EmployeeChallenge.Tests
{
    using AutoMapper;
    using EmployeeChallenge.Common.CustomExceptions;
    using EmployeeChallenge.Data.Repositories.Abstractions;
    using EmployeeChallenge.Dtos;
    using EmployeeChallenge.Entities;
    using EmployeeChallenge.Services;
    using EmployeeChallenge.Services.Abstractions;
    using Moq;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class EmployeesServiceTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
        private readonly Mock<ISkillAssigmentRepository> _mockSkillAssigmentRepository;
        private readonly Mock<ISkillRepository> _mockSkillRepository;
        private readonly IEmployeesService _employeesService;

        public EmployeesServiceTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockEmployeeRepository = new Mock<IEmployeeRepository>();
            _mockSkillAssigmentRepository = new Mock<ISkillAssigmentRepository>();
            _mockSkillRepository = new Mock<ISkillRepository>();
            _employeesService = new EmployeesService(_mockMapper.Object, _mockEmployeeRepository.Object,
                                                    _mockSkillAssigmentRepository.Object, _mockSkillRepository.Object);
        }

        [Fact]
        public async Task GetEmployeeAsyncWillReturnTheRightTypeAndIdOfEmployee()
        {
            var employeeID = Guid.NewGuid();
            var employee = new Employee()
            {
                ID = employeeID,
                FirstName ="Bill",
                LastName ="Papadopoulos",
                Address = new Address()
                {
                    ID = Guid.NewGuid(),
                    AddressLine = "Pireos 23",
                    City = "Piraeus",
                    Country ="Greece"
                }

            };

            _mockEmployeeRepository.Setup(x => x.GetSingleOrDefaultEmployeeAsync(employeeID)).ReturnsAsync(employee);
            _mockMapper.Setup(x => x.Map<Employee, EmployeeDto>(employee)).Returns(new EmployeeDto() { ID = employeeID });

            var result = await _employeesService.GetEmployeeAsync(employeeID);

            Assert.True(result.ID == employeeID);

            Assert.IsType<EmployeeDto>(result);

        }

        [Fact]
        public async Task RemoveSkillFromEmployeeAsyncWillFailWhenEmployeeDoesNotHaveSkill()
        {

            var skillID = Guid.NewGuid();
            var employeeID = Guid.NewGuid();

            _mockSkillAssigmentRepository.Setup(x => x.EmployeeHasSkillAsync(employeeID, skillID)).ReturnsAsync(false);

            _mockSkillAssigmentRepository.Setup(x => x.RemoveSkillFromEmployeeAsync(employeeID, skillID));
            _mockSkillAssigmentRepository.Setup(x => x.CommitAsync());


            await Assert.ThrowsAsync<CustomEntryExistsException>(
                async()=> await _employeesService.RemoveSkillFromEmployeeAsync(employeeID, skillID));

        }
    }
}
