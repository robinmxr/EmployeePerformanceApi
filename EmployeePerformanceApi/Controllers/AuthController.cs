using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using EmployeePerformanceApi.DTO;
using EmployeePerformanceApi.Models;
using EmployeePerformanceApi.Data;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly EmployeePerformanceDbContext _context;
    private readonly IConfiguration _config;

    public AuthController(EmployeePerformanceDbContext context, IConfiguration config)
    {
        _context = context;
        _config = config;
    }

    // 🔹 User Registration
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto request)
    {
        if (_context.Users.Any(u => u.UserName == request.UserName))
            return BadRequest("User already exists!");

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,  
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password) // Hash Password
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok(new { message = "User registered successfully!" });
    }

    // 🔹 User Login
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto request)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized("Invalid credentials");

        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }

    // 🔹 Generate JWT Token
    private string GenerateJwtToken(User user)
    {
        var jwtKey = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
        var claims = new List<Claim> {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(jwtKey), SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

