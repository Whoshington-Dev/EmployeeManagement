using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Repositories
{
    public interface IDepartmentRepository
    {
        public Task<Department> GetByNameAsync(string dptName);
        public Task<Department> AddAsync(string dptName);
    }
}
