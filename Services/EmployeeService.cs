using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public void AddEmployee(string cpf, string name, Department department, Seniority seniority, JobPosition jobPosition, DateTime admissionDate)
        {
            Employee employee = new Employee(cpf, name, department, seniority, jobPosition, admissionDate);
            _repository.Add(employee);
        }
        public void EditEmployee(string cpf, Department department, JobPosition jobPosition, Seniority seniority)
        {
            Employee employee = _repository.GetByCpf(cpf);

            employee.ChangeDepartment(department);
            employee.ChangeJobPosition(jobPosition);
            employee.ChangeSeniority(seniority);

            _repository.Update(employee);

        }
        public void LayOffEmployee(string cpf, DateTime TerminationDate, string reason)
        {
            Employee employee = _repository.GetByCpf(cpf);
            employee.LayOff(TerminationDate, reason);
            _repository.Update(employee);
        }
        public IList<Employee> GetEmployees()
        {
            return _repository.GetAll();
        }


    }
}
