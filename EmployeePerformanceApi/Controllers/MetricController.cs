using Microsoft.AspNetCore.Mvc;
using EmployeePerformanceApi.Data;
using EmployeePerformanceApi.Models;

[Route("api/[controller]")]
[ApiController]
public class MetricController : ControllerBase
{
    private readonly EmployeePerformanceDbContext _context;

    public MetricController(EmployeePerformanceDbContext context)
    {
        _context = context;
    }

    [HttpGet("{employeeId}")]
    public IActionResult GetMetrics(int employeeId)
    {
        var metrics = _context.Metrics.Where(m => m.EmployeeId == employeeId).ToList();
        return Ok(metrics);
    }

    [HttpPost("{employeeId}")]
    public IActionResult AddMetric(int employeeId, [FromBody] Metric metric)
    {
        if (ModelState.IsValid)
        {
            metric.EmployeeId = employeeId;
            _context.Metrics.Add(metric);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMetrics), new { employeeId = employeeId }, metric);
        }
        return BadRequest(ModelState);
    }
}
