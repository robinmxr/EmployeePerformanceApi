using Microsoft.EntityFrameworkCore;
using EmployeePerformanceApi.Models;

namespace EmployeePerformanceApi.Data
{
    public class EmployeePerformanceDbContext : DbContext
    {
        public EmployeePerformanceDbContext(DbContextOptions<EmployeePerformanceDbContext> options) : base(options)
        { }
    

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
