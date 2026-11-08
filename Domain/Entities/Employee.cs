using EmployeeManagement.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace EmployeeManagement.Domain.Entities
{
    [Table("Employees")]
    public class Employee
    {
        public int Id { get; set; }
        public string Cpf { get; private set; }
        public string Name { get; private set; }
        public DateTime DateOfAdmission { get; private set; }
        public Seniority Seniority { get; private set; }
        public EmployeeStatus EmployeeStatus { get; private set; }
        public Department Department { get; private set; }
        public int DepartmentId { get; set; }
        public JobPosition JobPosition { get; private set; }
        public int JobPositionId { get; set; }
        public DateTime? TerminationDate { get; private set; }
        public string? TerminationReason { get; private set; }

        public Employee() { }

        // Registration Of New Employees
        public Employee(string cpf, string name, Department department, JobPosition jobPosition, Seniority seniority, DateTime dateOfAdmission, DateTime today)
        {

            if (string.IsNullOrWhiteSpace(name))
            { // If what was typed is null, empty, or consists only of spaces, an exception will be thrown.
                throw new ArgumentNullException($"Invalid name entered! Please try again. {nameof(name)}");
            }
            Cpf = cpf;
            Name = name;
            Department = department;
            JobPosition = jobPosition;
            Seniority = seniority;
            DateOfAdmission = dateOfAdmission;
            // Admission status 
            EmployeeStatus = CompanyTenure(dateOfAdmission, today);
        }

        private int CalculateDays(DateTime date, DateTime today)
        {
            return (int)(today - date).TotalDays;
        }

        public EmployeeStatus CompanyTenure(DateTime admissionDate, DateTime today)
        {

            int days = CalculateDays(admissionDate, today);
            return days < 90 ? EmployeeStatus.InExperience : EmployeeStatus.Active;
        }
        public EmployeeStatus EndDays(DateTime endOfContract, DateTime today)
        {
            int endDays = CalculateDays(endOfContract, today);
            // Layoff
            return endDays <= 30 ? EmployeeStatus.EndOfContract : EmployeeStatus.EndOfContract;
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