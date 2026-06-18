using EmployeeManagement.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace Employee_Management_API.DTOs
{
    // DTO of Creation Employee
    public record DTOAddition
    {
        [Required]
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Department { get; set; }
        public string JobPositionName { get; set; }
        public Seniority Seniority { get; set; }
        public DateTime DateOfAdmission { get; set; }
    }
}
