
using EmployeePerformanceApi.Data;
using Microsoft.EntityFrameworkCore;
using Hangfire;
using Hangfire.Redis.StackExchange;
using EmployeePerformanceApi.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EmployeePerformanceApi
{
    public class Program
    {
        public static async Task Main(string[] args)
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
            var jwtSettings = builder.Configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .       AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
            {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });

            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EmployeePerformanceDbContext>();
                SeedData.Initialize(context);
            }

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
