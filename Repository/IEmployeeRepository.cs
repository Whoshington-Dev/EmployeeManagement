using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Repository
{
    public interface IEmployeeRepository
    {
        // Acess Employee 
        public Task<Employee> GetByCpfAsync(string Cpf);
        public Task<IList<Employee>> GetAllAsync();
        public Task AddAsync(Employee employee);
        public Task UpdateAsync(Employee employee);
        public Task RemoveAsync(Employee employee); 
    }
}