using Bogus;
using EmployeePerformanceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePerformanceApi.Data
{
    public class EmployeeSeeder
    {
        private readonly EmployeePerformanceDbContext _context;

        public EmployeeSeeder(EmployeePerformanceDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            if (await _context.Employees.AnyAsync())
            {
                return; // DB has been seeded
            }
            try
            {

                var faker = new Faker<Employee>()
                    .RuleFor(e => e.Name, f => f.Name.FullName())
                    .RuleFor(e => e.Email, f => f.Internet.Email())
                    .RuleFor(e => e.Department, f => f.Commerce.Department())
                    .RuleFor(e => e.Designation, f => f.Name.JobTitle())
                    .RuleFor(e => e.Phone, f => f.Phone.PhoneNumber())
                    .RuleFor(e => e.Metrics, f => new List<Metric>());

                var employees = faker.Generate(100);

                await _context.Employees.AddRangeAsync(employees);
                await _context.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
            }
        }
    }
}
