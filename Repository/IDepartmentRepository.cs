using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Repository
{
    public interface IDepartmentRepository
    {
        public Task<Department> GetByNameAsync(string dptName);
        public Task<Department> AddDepartmentAsync(string dptName);
    }
}
