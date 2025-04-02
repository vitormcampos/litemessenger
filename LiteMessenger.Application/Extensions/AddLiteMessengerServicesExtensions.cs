using LiteMessenger.Application.Services;
using LiteMessenger.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LiteMessenger.Application.Extensions;

public static class AddLiteMessengerServicesExtension
{
    public static IServiceCollection AddLiteMessengerServices(this IServiceCollection services)
    {
        // TODO: Alterar connection string para .env
        var connectionString = "server=localhost;database=lite_messenger;user=root;password=5887;";
        services.AddDbContext<LiteMessengerContext>(config =>
        {
            config.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });

        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
