using EmployeeManagement.Domain.Entities.Enums;

namespace EmployeeManagement.Domain.Entities
{
    public class JobPosition
    {
        public string jobPosition { get; set; }
        public Department Department { get; set; }
        public Seniority Seniority { get; set; }

        public JobPosition() { }

        public JobPosition(string post, Department department, Seniority seniority)
        {
            if (string.IsNullOrWhiteSpace(post))
            {
                throw new ArgumentNullException($"Invalid name entered! Please try again. {nameof(post)}");
            }
            jobPosition = post;
            Department = department;
            Seniority = seniority;
        }

    }
}
