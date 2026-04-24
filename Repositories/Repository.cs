using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Repository;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbContextEF _context;

        public EmployeeRepository(DbContextEF context)
        {
            _context = context;
        }

        public void Add(Employee employee)
        
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }
        public Employee GetByCpf(string Cpf)
        {
            return _context.Employees.FirstOrDefault(emp => emp.Cpf == Cpf);

        }
        public IList<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

    }
}