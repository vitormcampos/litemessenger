namespace LiteMessenger.Domain.Models;

public sealed class Chat
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public List<Message> Messages { get; private set; } = [];

    public Chat(string id, string name)
    {
        Id = id;
        Name = name;
    }

    private Chat() { }
}
