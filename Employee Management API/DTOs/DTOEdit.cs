using EmployeeManagement.Domain.Entities.Enums;

namespace Employee_Management_API.DTOs
{
    public class DTOEdit
    {
        public string Cpf { get; set; }
        public Seniority Seniority { get; set; }
        public string Department { get; set; }
        public string JobPosition { get; set; }
    }
}
