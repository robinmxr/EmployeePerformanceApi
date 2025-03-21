using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeePerformanceApi.Data;

namespace EmployeePerformanceApi.Controllers
{
    public class UserController : Controller
    {
        private readonly EmployeePerformanceDbContext _context;
        public UserController(EmployeePerformanceDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("assign-role")]
        public IActionResult AssignRole(string userName, string role)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null) return NotFound("User not found");

            user.Role = role;
            _context.SaveChanges();

            return Ok($"Role {role} assigned to {userName}");
        }

    }
}
