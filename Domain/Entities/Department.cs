using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Domain.Entities
{
    [Table("Department")]

    public class Department
    {
        public int Id { get; set; }
        public string DptName { get; private set; }

        public Department(string dptName)
        {
            DptName = dptName;

            if (string.IsNullOrWhiteSpace(dptName))
            { // If what was typed is null, empty, or consists only of spaces, an exception will be thrown.
                throw new ArgumentNullException("Invalid name entered! Please try again. ", nameof(dptName));
            }
        }
    }
}