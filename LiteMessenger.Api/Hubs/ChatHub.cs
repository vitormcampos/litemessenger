using LiteMessenger.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace LiteMessenger.Api.Hubs;

// [Authorize]
public class ChatHub(IUserService userService) : Hub
{
    private readonly IUserService userService = userService;

    // Método para enviar mensagem para todos os clientes conectados
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    // Método chamado quando um cliente se conecta
    public override async Task OnConnectedAsync()
    {
        //await userService.ChangeStatusTo(Context.User.Identity.Name, 1);

        var userId = Context.User?.FindFirst("sub")?.Value; // ou outro claim que você quiser
        var userName = Context.User?.Identity?.Name;

        Console.WriteLine($"Usuário conectado: {userName} (ID: {userId})");

        await base.OnConnectedAsync();
    }

    // Método chamado quando um cliente se desconecta
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
        //await userService.ChangeStatusTo(Context.User.Identity.Name, 0);

        Console.WriteLine($"Cliente desconectado: {Context.ConnectionId}");
        Console.WriteLine($"Cliente desconectado: {Context.User.Identity.Name}");
    }
}
