using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Repository;
using EmployeeManagement.Services;
using Moq;
using System.Xml.Linq;
using Xunit;

namespace EmployeeManagement.Tests.Services
{
    public class EmployeeServiceTests
    {
        // DI 
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly Mock<IDepartmentRepository> _departmentRepositoryMock;
        private readonly Mock<IJobPositionRepository> _jobRepositoryMock;

        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            // Injection 
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _departmentRepositoryMock = new Mock<IDepartmentRepository>();
            _jobRepositoryMock = new Mock<IJobPositionRepository>();

            _employeeService = new EmployeeService(
                _employeeRepositoryMock.Object, 
                _departmentRepositoryMock.Object,
                _jobRepositoryMock.Object
            );
        }


        private Employee CreateValidEmployee(string name = "John Doe")
        {
            var department = new Department("IT");
            var jobPosition = new JobPosition("Developer", department, Seniority.Junior);
            return new Employee(
                "12345678900",
                name,
                department,
                jobPosition,
                Seniority.Junior,
                DateTime.Parse("2023-01-01")
            );
        }
        [Fact]
        public async Task AddEmployeeAsync_WhenDepartmentAndJobPositionExist_AddsEmployeeWithoutCreatingThem()
        {
            // Arrange
            string cpf = "07511107109";
            string name = "Whoshington Luis";
            var department = new Department("IT");
            var jobPosition = new JobPosition("Developer", department, Seniority.Junior);
            var seniority = Seniority.Junior;
            var dtOfAdm = DateTime.Parse("2023-01-01");
            // Stub
            _departmentRepositoryMock
                .Setup(repo => repo.GetByNameAsync(department.DptName))
                .ReturnsAsync(department);
            _jobRepositoryMock
                .Setup(repo => repo.GetByNameAsync(jobPosition.JobPositionName, department, seniority))
                .ReturnsAsync(jobPosition);

            //Act 
            await _employeeService.AddEmployeeAsync(cpf, name, department, jobPosition, seniority, dtOfAdm);
        }        
    }
}