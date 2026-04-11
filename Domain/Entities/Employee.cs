using EmployeeManagement.Domain.Entities.Enums;

namespace EmployeeManagement.Domain.Entities
{
    public class Employee
    {
        public string Name { get; private set; }
        public string Cpf { get; private set; }
        private readonly string _internalId = Guid.NewGuid().ToString(); // The ID cannot be changed.
        public DateTime DateOfAdmission { get; private set; }
        public Seniority Seniority { get; private set; }
        public EmployeeStatus EmployeeStatus { get; private set; }
        public Department Department { get; private set; }
        public JobPosition JobPosition { get; private set; }
        public DateTime TerminationDate { get; private set; }
        public string TerminationReason { get; private set; }

        public Employee() { }

        // Registration Of New Employees
        public Employee(string cpf, string name, Department department, Seniority seniority, JobPosition jobPosition, DateTime dateOfAdmission)
        {

            if (string.IsNullOrWhiteSpace(name))
            { // If what was typed is null, empty, or consists only of spaces, an exception will be thrown.
                throw new ArgumentNullException($"Invalid name entered! Please try again. {nameof(name)}");
            }
            Cpf = cpf;
            Name = name;
            Department = department;
            Seniority = seniority;
            JobPosition = jobPosition;
            DateOfAdmission = dateOfAdmission;
            // Admission status 
            EmployeeStatus = CompanyTenure(dateOfAdmission);
        }

        private int CalculateDays(DateTime date, DateTime? referenceDate = null)
        {
            DateTime reference = referenceDate ?? DateTime.Today;
            return (int)(reference - date).TotalDays;
        }

        public EmployeeStatus CompanyTenure(DateTime admissionDate, DateTime? referenceDate = null)
        {

            int days = CalculateDays(admissionDate);
            // hired
            if (days <= 90)
            {
                return EmployeeStatus.InExperience;
            }
            else
            {
                return EmployeeStatus.Active;
            }            
        }
        public EmployeeStatus EndDays(DateTime endOfContract)
        {
            int endDays = CalculateDays(endOfContract);
            // Layoff
            if (endDays <= 30)
            {
                return EmployeeStatus.EndOfContract;
            }
            else
            {
                return EmployeeStatus.Fired;
            }
        }
        public void LayOff(DateTime terminationDate, string terminationReason)
        {
            if (EmployeeStatus == EmployeeStatus.Fired)
            {
                throw new InvalidOperationException("Data cannot be overwritten.");
            }

            EmployeeStatus = EmployeeStatus.Fired;
            TerminationDate = terminationDate;
            TerminationReason = terminationReason;
        }
        private void UserStatus()
        {
            if (EmployeeStatus == EmployeeStatus.Fired)
            {
                throw new InvalidOperationException("The employee is not in the system, please try again.");
            }
        }
        public void Responsibilities(Department department, JobPosition jobPosition, Seniority seniority)
        {
            // Method for registering a new employee.
            UserStatus();
            Department = department;
            JobPosition = jobPosition;
            Seniority = seniority;

        }
        // Methods for editing
        public void ChangeDepartment(Department department)
        {
            UserStatus();
            Department = department;
        }
        public void ChangeJobPosition(JobPosition jobPosition)
        {
            UserStatus();
            JobPosition = jobPosition;
        }
        public void ChangeSeniority(Seniority seniority)
        {
            UserStatus();
            Seniority = seniority;

        }
    }
}