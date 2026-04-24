using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Repositories
{
    public interface IDepartmentRepository
    {
        public Department GetByName(string dptName);
        public Department Add(string dptName);
    }
}
