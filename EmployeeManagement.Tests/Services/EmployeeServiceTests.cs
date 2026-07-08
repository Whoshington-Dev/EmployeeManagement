using Xunit;
using Moq;
using EmployeeManagement.Repository;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Services;

namespace EmployeeManagement.Tests.Services
{
    public class EmployeeServiceTests
    {

        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly Mock<IDepartmentRepository> _DepartmentRepositoryMock;
        private readonly Mock<IJobPositionRepository> _JobRepositoryMock;

        private readonly EmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _DepartmentRepositoryMock = new Mock<IDepartmentRepository>();
            _JobRepositoryMock = new Mock<IJobPositionRepository>();

            _employeeService = new EmployeeService(
                _employeeRepositoryMock.Object, 
                _DepartmentRepositoryMock.Object,
                _JobRepositoryMock.Object
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
    }
}
