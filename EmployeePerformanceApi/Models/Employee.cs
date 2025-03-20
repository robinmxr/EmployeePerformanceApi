namespace EmployeePerformanceApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string? Phone { get; set; }


        public List<Metric> Metrics { get; set; }
    }
}
