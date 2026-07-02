using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthLab.Configuration;
using JwtAuthLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;





namespace JwtAuthLab.Controllers;


[ApiController]
[Route("api/[controller]")]


public class AuthController : ControllerBase
{
    private readonly JwtSettings _jwtSettings;

    public AuthController(IConfiguration configuration)
    {
        _jwtSettings = configuration
            .GetSection("JwtSettings")
            .Get<JwtSettings>()
            ?? throw new InvalidOperationException("JwtSettings is missing in configuration.");
    }


    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // In a real application, this should be replaced with Identity or database validation.
        if (request.Username != "admin" || request.Password != "hemligt")
        {
            return Unauthorized("Ogiltiga användaruppgifter.");
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, request.Username),
            new(ClaimTypes.Role, "Admin")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials
        );

        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }

}