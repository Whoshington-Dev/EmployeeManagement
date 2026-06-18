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
        public async Task<IActionResult> AddEmployee([FromBody] DTOAddition dtoAdd)
        {
            await _service.AddEmployeeAsync(dtoAdd.Cpf, dtoAdd.Name, new Department(dtoAdd.Department),
                new JobPosition(dtoAdd.JobPositionName, new Department(dtoAdd.Department), dtoAdd.Seniority), dtoAdd.Seniority, dtoAdd.DateOfAdmission
                );
            return Created(); // 201 
        }
        [HttpPut]
        public async Task<IActionResult> EditEmployee([FromBody] DTOEdit dtoEdit)
        {
            await _service.EditEmployeeAsync(dtoEdit.Cpf, new Department(dtoEdit.Department),
                new JobPosition(dtoEdit.JobPositionName, new Department(dtoEdit.Department), dtoEdit.Seniority), dtoEdit.Seniority);
            return NoContent(); // 204
        }
        [HttpPatch]
        public async Task<IActionResult> LayOff([FromBody] DTOLayOff dtoLayOff)
        {
            await _service.LayOffEmployeeAsync(dtoLayOff.Cpf, dtoLayOff.TerminationDate, dtoLayOff.Reason);
            return NoContent(); // 204 
        }
        [HttpGet]
        public async Task<IActionResult> Employee()
        {
            var employees = await _service.GetEmployeesAsync();
            var response = employees.Select(emp => new DTOResponse
            {
                Cpf = emp.Cpf,
                Name = emp.Name,
                DateOfAdmission = emp.DateOfAdmission,
                Status = emp.EmployeeStatus
            }).ToList();

            return Ok(response); // 200
        }
    }
}