using EmployeeManagement.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities
{
    [Table("JobPosition")]
    public class JobPosition
    {
        public int Id { get; set; }
        [Column("jobTitle")]
        public string JobPositionName { get; private set; }
        public Seniority Seniority { get; set; }

        public JobPosition() { }

        public JobPosition(string jobPosition, Seniority seniority)
        {
            if (string.IsNullOrWhiteSpace(jobPosition))
            {
                throw new ArgumentNullException($"Invalid name entered! Please try again. {nameof(jobPosition)}");
            }
            JobPositionName = jobPosition;
            Seniority = seniority;
        }

    }
}
