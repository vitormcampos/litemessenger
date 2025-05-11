using LiteMessenger.Application.Services;
using LiteMessenger.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiteMessenger.Application.Extensions;

public static class AddLiteMessengerServicesExtension
{
    public static IServiceCollection AddLiteMessengerServices(this IServiceCollection services)
    {
        var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

        // TODO: Alterar connection string para .env
        var connectionString = configuration.GetConnectionString("LiteMessengerDb");
        services.AddDbContext<LiteMessengerContext>(config =>
        {
            config.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

        return services;
    }
}
