using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Infrastructure;


namespace EmployeeManagement.Repositories
{
    public class JobPositionRepository : IJobPositionRepository
    {

        private readonly DbContextEF _context;

        public JobPositionRepository(DbContextEF context)
        {
            _context = context;
        }

        public JobPosition GetByName(string JobPositionName, Department department, Seniority seniority)
        {
            return _context.JobPositions.FirstOrDefault(jp => jp.JobPositionName == JobPositionName && jp.Department == department && jp.Seniority == seniority);
        }
        public JobPosition Add(string JobPositionName, Department department, Seniority seniority)
        {
            var jobPosition = new JobPosition(JobPositionName, department, seniority);
            _context.JobPositions.Add(jobPosition);
            _context.SaveChanges();
            return jobPosition;
        }
    }
}