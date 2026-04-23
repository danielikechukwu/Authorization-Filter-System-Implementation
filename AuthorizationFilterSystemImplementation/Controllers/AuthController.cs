using AuthorizationFilterSystemImplementation.DTOs;
using AuthorizationFilterSystemImplementation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationFilterSystemImplementation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController
{
    private readonly IConfiguration _configuration;
    
    // In-memory hardcoded users list for demo (simulate a user database)
    private readonly List<User> _users = new List<User>()
    {
        new User {Id = 1, Email ="Alice@Example.com", Name = "Alice", Password = "alice123", Roles = "Admin,Manager" },
        new User {Id = 2, Email ="Bob@Example.com", Name = "Bob", Password = "bob123", Roles = "User" },
        new User {Id = 3, Email ="Charlie@Example.com", Name = "Charlie", Password = "charlie123", Roles = "Manager,User" }
    };
    
    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    // This endpoint is accessible by anyone, even unauthenticated users
    [HttpPost("LoginCredential")]
    [AllowAnonymous]
    private IActionResult Login([FromBody] LoginDTO loginDto)
    {
        // Find a user in our hardcoded list that matches the provided email and password (case-insensitive email check)
        var user = _users.FirstOrDefault(u => u.Email.Equals(loginDto.Email, StringComparison.OrdinalIgnoreCase) && u.Password == loginDto.Password);

        if (user == null)
        {
            // If no matching user, credentials are invalid — respond with 401 Unauthorized status code
            
        }
    }
}