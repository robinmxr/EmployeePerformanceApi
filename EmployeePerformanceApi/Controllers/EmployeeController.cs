using EmployeePerformanceApi.Models;
using Microsoft.AspNetCore.Mvc;
using EmployeePerformanceApi.Services;
using EmployeePerformanceApi.DTO;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetEmployees()
    {
        var employees = _service.GetEmployees();
        return Ok(employees);
    }

    [HttpGet]
    [Route("{id}")]
    public IActionResult GetEmployee(int id)
    {
        var employee = _service.GetEmployee(id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employee);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDTO employeeDto)
    {
        if (ModelState.IsValid)
        {
            var createdEmployee = await _service.AddEmployee(employeeDto);

            if (createdEmployee != null)
            {
                return CreatedAtAction(
                    nameof(GetEmployees),
                    new { id = createdEmployee.Id },  
                    createdEmployee  
                );
            }


            return BadRequest("Failed to create employee.");
        }
        return BadRequest(ModelState);
    }
}
