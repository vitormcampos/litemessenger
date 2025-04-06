using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LiteMessenger.Domain.Interfaces.Services;
using LiteMessenger.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LiteMessenger.Application.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;

    public AuthService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateJwtToken(User user)
    {
        var jwtSettings = _config.GetSection("Jwt");

        if (jwtSettings is null || jwtSettings["Key"] is null)
        {
            throw new Exception("JWT settings not found in configuration.");
        }

        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim("name", user.Name!),
            new Claim("status", user.Status.ToString()),
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpireMinutes"]!)),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
