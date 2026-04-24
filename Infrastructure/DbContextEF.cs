using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure
{
    public class DbContextEF : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbContextEF(DbContextOptions<DbContextEF> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobPosition)
                .WithMany()
                .HasForeignKey(e => e.JobPositionId);

            modelBuilder.Entity<JobPosition>()
                .HasOne(jp => jp.Department)
                .WithMany()
                .HasForeignKey(jp => jp.DepartmentId);
        }

    }
}
