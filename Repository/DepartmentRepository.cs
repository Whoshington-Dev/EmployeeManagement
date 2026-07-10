using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbContextEF _context;

        public DepartmentRepository(DbContextEF context)
        {
            _context = context;
        }

        public async Task<Department> GetByNameAsync(string dptName)
        {
            return await _context.Departments.FirstOrDefaultAsync(dep => dep.DptName == dptName);
        }
        public async Task<Department> AddAsync(string dptName)
        {
            var department = new Department(dptName );
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();
            return department;
        }

    }
}
