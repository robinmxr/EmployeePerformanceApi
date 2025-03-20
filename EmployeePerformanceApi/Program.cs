
using EmployeePerformanceApi.Data;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.Redis.StackExchange;

namespace EmployeePerformanceApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EmployeePerformanceDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EmployeePerformanceDb")));
            //builder.Services.AddStackExchangeRedisCache(options =>
            //{
            //    options.Configuration = "localhost:6379,abortConnect=false";
            //    options.InstanceName = "EmployeePerformanceApi";
            //});
            //builder.Services.AddHangfire(config => config.UseRedisStorage("localhost:6379"));
            //builder.Services.AddHangfireServer();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHangfireDashboard();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
