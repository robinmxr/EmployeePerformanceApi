namespace EmployeePerformanceApi.Models
{
    public class Metric
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string MetricName { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public Employee Employee { get; set; }

    }
}
