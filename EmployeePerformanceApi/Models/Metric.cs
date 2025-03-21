namespace EmployeePerformanceApi.Models
{
    public class Metric
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int DaysPresent { get; set; } // Total attendance days
        public int LeaveTaken { get; set; } // Leave days
        public int TotalWorkHours { get; set; } // Sum of daily work hours
        public double AvgDailyWorkHours { get; set; } // Average work hours per day
        public int TasksCompleted { get; set; } // Number of completed tasks
        public double OnTimeCompletionRate { get; set; } // Percentage of tasks completed on time
        public int ProjectsWorkedOn { get; set; } // Count of projects contributed
        public double ContributionScore { get; set; }
        public DateTime Date { get; set; }

        public Employee Employee { get; set; }

    }
}
