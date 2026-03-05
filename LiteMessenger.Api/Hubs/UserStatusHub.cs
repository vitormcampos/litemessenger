using LiteMessenger.Api.Extensions;
using LiteMessenger.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace LiteMessenger.Api.Hubs;

[Authorize]
public class UserStatusHub(IUserService userService) : Hub
{
    // Método chamado quando um cliente se conecta
    public override async Task OnConnectedAsync()
    {
        var userId = Context.User?.GetUserId();

        if (userId is not null)
        {
            await userService.ChangeStatusTo(userId, 1);
        }

        await SendUpdateOnlineUsers();

        await base.OnConnectedAsync();
    }

    // Método chamado quando um cliente se desconecta
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var userId = Context.User?.GetUserId();
        if (userId is not null)
        {
            await userService.ChangeStatusTo(userId ?? string.Empty, 0);
        }

        await SendUpdateOnlineUsers();

        await base.OnDisconnectedAsync(exception);
    }

    private async Task SendUpdateOnlineUsers()
    {
        var onlineUsers = await userService.GetOnlineUsers();
        await Clients.All.SendAsync("UpdateOnlineUsers", onlineUsers);
    }
}
