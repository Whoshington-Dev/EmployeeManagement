using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Repository;
using EmployeeManagement.Repositories;


namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IDepartmentRepository _department;
        private readonly IJobPositionRepository _jobPosition;

        public EmployeeService(IEmployeeRepository repository, IDepartmentRepository department, IJobPositionRepository jobPosition)
        {
            _repository = repository;
            _department = department;
            _jobPosition = jobPosition;
        }
        public void AddEmployee(string cpf, string name, Department department, JobPosition jobPosition, Seniority seniority, DateTime admissionDate)
        {
            var dep = _department.GetByName(department.DptName);
            if (dep == null)
            {
                dep = _department.Add(department.DptName);
            }
            var jp = _jobPosition.GetByName(jobPosition.JobPositionName, dep, seniority);
            if (jp == null)
            {
                jp = _jobPosition.Add(jobPosition.JobPositionName, dep, seniority);
            }

            Employee employee = new Employee(cpf, name, dep, jp, seniority, admissionDate);
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
