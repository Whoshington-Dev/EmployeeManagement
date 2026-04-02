using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Services
{
    class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        List<Employee> employees;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public void AddEmployee(string cpf, string name, Department department, Seniority seniority, JobPosition jobPosition, DateTime admissionDate)
        {
            Employee employee = new Employee(cpf, name, department, seniority, jobPosition, admissionDate);
            _repository.Add(employee);
        }
        public void EditEmployee(string cpf)
        {
            Employee employee = employees.First(emp => emp.Cpf == cpf);


            int editing = int.Parse(Console.ReadLine());
            switch (editing)
            {
                case 1:
                    Console.Write("New Department: ");
                    string newDepartmentName = Console.ReadLine();
                    Department department = new Department(dptName: newDepartmentName);
                    employee.ChangeDepartment(department);
                    break;

                case 2:
                    Console.Write("New Job Position: ");
                    string newPositionTitle = Console.ReadLine();
                    JobPosition jobPosition = new JobPosition(newPositionTitle, employee.Department, employee.Seniority);
                    employee.ChangeJobPosition(jobPosition);
                    break;

                case 3:
                    Console.Write("New seniority: ");
                    string seniorityInput = Console.ReadLine();
                    Enum.TryParse<Seniority>(seniorityInput, out Seniority result);

                    employee.ChangeSeniority(result);
                    break;
            }
            _repository.Update(employee);

        }
        public void LayOffEmployee(string cpf, DateTime laidOff, string reason)
        {
            Employee employee = employees.First(employees => employees.Cpf == cpf);
            employee.LayOff(laidOff, reason);
            _repository.Update(employee);
        }
    }
}
