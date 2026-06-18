using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;

namespace EmployeeManagement.Repositories
{
    public interface IJobPositionRepository
    {
        public Task<JobPosition> GetByNameAsync(string JobPositionName, Department department, Seniority seniority);
        public Task<JobPosition> AddAsync(string JobPositionName, Department department, Seniority seniority);
    }
}
