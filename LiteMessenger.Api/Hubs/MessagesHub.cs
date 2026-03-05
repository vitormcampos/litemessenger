using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace LiteMessenger.Api.Hubs;

[Authorize]
public class MessagesHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task ReceiveMessage(string receiverId, string message)
    {
        await Clients.User(receiverId).SendAsync("ReceiveMessage", message);
    }
}
