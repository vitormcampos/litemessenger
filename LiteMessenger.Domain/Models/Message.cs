namespace LiteMessenger.Domain.Models;

public sealed record Message
{
    public string Id { get; init; }
    public string ChatId { get; init; }
    public Chat Chat { get; init; }
    public string UserId { get; init; }
    public User User { get; init; }
    public string TimeStamp { get; init; }
    public string Content { get; init; }
}
