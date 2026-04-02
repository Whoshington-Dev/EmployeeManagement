using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Repositories
{
    class EmployeeRepository : IEmployeeRepository
    {
        List<Employee> employees = new List<Employee>();

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }
        public void Remove(Employee employee)
        {
            employees.Remove(employee);
        }
        public void Update(Employee employee)
        {
            int index = employees.FindIndex(emp => emp.Cpf == employee.Cpf);
            employees[index] = employee;
        }
        public Employee GetByCpf(string Cpf)
        {
            return employees.First(emp => emp.Cpf == Cpf);
        }
        public IList<Employee> GetAll()
        {
            return employees.ToList();
        }

    }
}