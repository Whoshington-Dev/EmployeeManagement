using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Entities.Enums;
using EmployeeManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Repositories
{
    public class JobPositionRepository : IJobPositionRepository
    {

        private readonly DbContextEF _context;

        public JobPositionRepository(DbContextEF context)
        {
            _context = context;
        }

        public async Task<JobPosition> GetByNameAsync(string JobPositionName, Department department, Seniority seniority)
        {
            return await _context.JobPositions.FirstOrDefaultAsync(jp => jp.JobPositionName == JobPositionName && jp.Department == department && jp.Seniority == seniority);
        }
        public async Task<JobPosition> AddAsync(string JobPositionName, Department department, Seniority seniority)
        {
            var jobPosition = new JobPosition(JobPositionName, department, seniority);
            await _context.JobPositions.AddAsync(jobPosition);
            await _context.SaveChangesAsync();
            return jobPosition;
        }
    }
}