using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;

namespace EmployeeManagement.Repositories
{
    public interface IJobPositionRepository
    {
        public JobPosition GetByName(string JobPositionName, Department department, Seniority seniority);
        public JobPosition Add(string JobPositionName, Department department, Seniority seniority);
    }
}
