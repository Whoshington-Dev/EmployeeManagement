using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure;
using EmployeeManagement.Repository;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbContextEF _context;

        public EmployeeRepository(DbContextEF context)
        {
            _context = context;
        }

        public async Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
        public async Task<Employee> GetByCpfAsync(string Cpf)
        {
             return await _context.Employees.FirstOrDefaultAsync(emp => emp.Cpf == Cpf);
        }
        public async Task<IList<Employee>> GetAllAsync()
        {
            return await _context.Employees.ToListAsync();
        }

    }
}