using EmployeePerformanceApi.DTO;
using EmployeePerformanceApi.Models;

namespace EmployeePerformanceApi.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> AddEmployee(EmployeeDTO employee);
    }
}
