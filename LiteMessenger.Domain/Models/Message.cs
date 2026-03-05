namespace LiteMessenger.Domain.Models;

public sealed class Message
{
    public string Id { get; private set; }
    public string ChatId { get; private set; }
    public Chat Chat { get; private set; } = null!;
    public string UserId { get; private set; }
    public User User { get; private set; } = null!;
    public string TimeStamp { get; private set; } = DateTime.UtcNow.ToString("o");
    public string Content { get; private set; }
}
