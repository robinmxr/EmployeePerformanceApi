using EmployeePerformanceApi.Data;
using EmployeePerformanceApi.DTO;
using EmployeePerformanceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePerformanceApi.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeePerformanceDbContext _context;

        public EmployeeService(EmployeePerformanceDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployee(EmployeeDTO employeeDto)
        {
            var employee = new Employee
            {
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Department = employeeDto.Department,
                Designation = employeeDto.Designation,
                Phone = employeeDto.Phone
            };
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }


        public Task<Employee> GetEmployee(int id)
        {
            var employee = _context.Employees.Include(e => e.Metrics).FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public Task<List<Employee>> GetEmployees()
        {
            var employees = _context.Employees.Include(e => e.Metrics).ToListAsync();
            return employees;
        }
    }
}
