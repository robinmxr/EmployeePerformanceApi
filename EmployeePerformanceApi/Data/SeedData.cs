using System;
using System.Collections.Generic;
using System.Linq;
using EmployeePerformanceApi.Models;

namespace EmployeePerformanceApi.Data
{
    public static class SeedData
    {
        public static void Initialize(EmployeePerformanceDbContext context)
        {
            if (!context.Employees.Any())
            {
                var employees = new List<Employee> {
                    new Employee { Name = "Alice Johnson", Email = "alice@company.com", Department="Software", Designation = "Software Engineer" },
                    new Employee { Name = "Bob Smith", Email = "bob@company.com", Department="Software",  Designation = "Project Manager" },
                    new Employee { Name = "Charlie Brown", Email = "cbrown@company.com" , Department="Software",  Designation = "Business Analyst" }
                };
                context.Employees.AddRange(employees);
                context.SaveChanges();

                var metrics = new List<Metric> {
                    new Metric {
                        EmployeeId = employees[0].Id, DaysPresent = 20, LeaveTaken = 2,
                        TotalWorkHours = 160, AvgDailyWorkHours = 8,
                        TasksCompleted = 10, OnTimeCompletionRate = 0.9,
                        ProjectsWorkedOn = 2, ContributionScore = 85
                    },
                    new Metric {
                        EmployeeId = employees[1].Id, DaysPresent = 18, LeaveTaken = 4,
                        TotalWorkHours = 144, AvgDailyWorkHours = 8,
                        TasksCompleted = 8, OnTimeCompletionRate = 0.75,
                        ProjectsWorkedOn = 3, ContributionScore = 92
                    },
                    new Metric {
                        EmployeeId = employees[2].Id, DaysPresent = 22, LeaveTaken = 1,
                        TotalWorkHours = 176, AvgDailyWorkHours = 8,
                        TasksCompleted = 12, OnTimeCompletionRate = 0.85,
                        ProjectsWorkedOn = 1, ContributionScore = 88
                    }

                };
                context.Metrics.AddRange(metrics);
                context.SaveChanges();
            }
        }
    }
}

