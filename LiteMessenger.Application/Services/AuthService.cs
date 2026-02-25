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
        var expirationDays = int.Parse(jwtSettings["ExpireDays"]!);

        var claims = new[]
        {
            new Claim(ClaimTypes.Sid, user.Id!),
            new Claim(ClaimTypes.Email, user.Email!),
            new Claim(ClaimTypes.Name, user.Name!),
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.Now.AddDays(expirationDays),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256
            )
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
