using Employee_Management_API.DTOs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _service; // DI 

        public EmployeeController(EmployeeService service)
        {
            _service = service; // constructor to allow instantiation of new objects
        }

        [HttpPost] // Verb for addition
        public IActionResult AddEmploye([FromBody] DTOAddition dtoAdd)
        {
            _service.AddEmployee(dtoAdd.Cpf, dtoAdd.Name, new Department(dtoAdd.Department),
                new JobPosition(dtoAdd.JobPositionName, new Department(dtoAdd.Department), dtoAdd.Seniority), dtoAdd.Seniority, dtoAdd.DateOfAdmission
                );
            return Created();
        }
        [HttpPut]
        public IActionResult EditEmployee([FromBody] DTOEdit dtoEdit)
        {
            _service.EditEmployee(dtoEdit.Cpf, new Department(dtoEdit.Department),
                new JobPosition(dtoEdit.JobPositionName, new Department(dtoEdit.Department), dtoEdit.Seniority), dtoEdit.Seniority);
            return NoContent();
        }
        [HttpPatch]
        public IActionResult LayOff([FromBody] DTOLayOff dtoLayOff)
        {
            _service.LayOffEmployee(dtoLayOff.Cpf, dtoLayOff.TerminationDate, dtoLayOff.Reason);
            return NoContent();
        }
        [HttpGet]
        public IActionResult Employee()
        {
            var employees = _service.GetEmployees();
            var response = employees.Select(emp => new DTOResponse
            {
                Cpf = emp.Cpf,
                Name = emp.Name,
                DateOfAdmission = emp.DateOfAdmission,
                Status = emp.EmployeeStatus
            }).ToList();

            return Ok(response);

        }
    }
}