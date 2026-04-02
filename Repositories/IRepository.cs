using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Repository
{
    interface IEmployeeRepository
    {
        // Acess Employee 
        public Employee GetByCpf(string Cpf);
        IList<Employee>GetAll();
        void Add(Employee employee);
        void Update(Employee employee);
        void Remove(Employee employee);

    }
}