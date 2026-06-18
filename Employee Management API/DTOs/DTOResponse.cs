using EmployeeManagement.Domain.Entities.Enums;

namespace Employee_Management_API.DTOs
{
    public record DTOResponse
    {
        public string Cpf { get; set; }
        public string Name { get; set; } 
        public DateTime DateOfAdmission { get; set; }
        public EmployeeStatus Status { get; set; }
    }
}
