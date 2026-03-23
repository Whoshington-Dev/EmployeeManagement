using EmployeeManagement.Domain.Entities.Enums;

namespace EmployeeManagement.Domain.Entities
{
    class JobPosition 
    {
        public string Post { get; set; }
        public Department Department { get; set; }
        public Seniority Seniority { get; set; }

        public JobPosition() { }

        
        public JobPosition(string post, Department department, Seniority seniority, EmployeeStatus employeeStatus)
        {
            Post = post;
            Department = department;
            Seniority = seniority;
        }
    }
}
