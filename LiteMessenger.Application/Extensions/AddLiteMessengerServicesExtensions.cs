using System.Text;
using LiteMessenger.Application.Services;
using LiteMessenger.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace LiteMessenger.Application.Extensions;

public static class AddLiteMessengerServicesExtension
{
    public static IServiceCollection AddLiteMessengerServices(this IServiceCollection services)
    {
        // get IConfiguration from builder
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        // TODO: Alterar connection string para .env
        var connectionString =
            "server=localhost;database=lite_messenger;user=root;password=dev123;";
        services.AddDbContext<LiteMessengerContext>(config =>
        {
            config.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        // Config JWT
        var jwtSettings = configuration.GetSection("Jwt");
        if (jwtSettings is null || jwtSettings["Key"] is null)
        {
            throw new Exception("JWT settings not found in configuration.");
        }

        var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);

        services
            .AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });

        services.AddAuthorization();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
