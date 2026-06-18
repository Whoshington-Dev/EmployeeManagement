using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Repository;
using EmployeeManagement.Repositories;

namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        // DI
        private readonly IEmployeeRepository _repository;
        private readonly IDepartmentRepository _department;
        private readonly IJobPositionRepository _jobPosition;

        public EmployeeService(IEmployeeRepository repository, IDepartmentRepository department, IJobPositionRepository jobPosition)
        {
            _repository = repository;
            _department = department;
            _jobPosition = jobPosition;
        }
        public async Task AddEmployeeAsync(string cpf, string name, Department department, JobPosition jobPosition, Seniority seniority, DateTime admissionDate)
        {
            var dep = await _department.GetByNameAsync(department.DptName);
            if (dep == null)
            {
                dep = await _department.AddAsync(department.DptName);
            }
            var jp = await _jobPosition.GetByNameAsync(jobPosition.JobPositionName, dep, seniority);
            if (jp == null)
            {
                jp = await _jobPosition.AddAsync(jobPosition.JobPositionName, dep, seniority);
            }

            Employee employee = new Employee(cpf, name, dep, jp, seniority, admissionDate);
            await _repository.AddAsync(employee);
        }
        public async Task EditEmployeeAsync(string cpf, Department department, JobPosition jobPosition, Seniority seniority)
        {
            Employee employee = await _repository.GetByCpfAsync(cpf);

            employee.ChangeDepartment(department);
            employee.ChangeJobPosition(jobPosition);
            employee.ChangeSeniority(seniority);

            await _repository.UpdateAsync(employee);

        }
        public async Task LayOffEmployeeAsync(string cpf, DateTime TerminationDate, string reason)
        {
            Employee employee = await _repository.GetByCpfAsync(cpf);
            employee.LayOff(TerminationDate, reason);
            await _repository.UpdateAsync(employee);
        }
        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            return await _repository.GetAllAsync();
        }


    }
}
