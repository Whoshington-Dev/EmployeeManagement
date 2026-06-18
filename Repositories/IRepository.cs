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
        // para que essa interface fique assincrona, eu precisei mudar o acesso de void pra public, isso é necessario porque em C#, o metodo assicrono não pode ser void
    }
}