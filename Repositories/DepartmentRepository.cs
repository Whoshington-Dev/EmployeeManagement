using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure;

namespace EmployeeManagement.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly DbContextEF _context;

        public DepartmentRepository(DbContextEF context)
        {
            _context = context;
        }

        public Department GetByName(string dptName)
        {
            return _context.Departments.FirstOrDefault(dep => dep.DptName == dptName);
        }
        public Department Add(string dptName)
        {
            var department = new Department(dptName );
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

    }
}
