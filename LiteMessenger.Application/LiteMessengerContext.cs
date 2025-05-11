using LiteMessenger.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LiteMessenger.Application;

public class LiteMessengerContext : DbContext
{
    public LiteMessengerContext(DbContextOptions<LiteMessengerContext> dbContextOptions)
        : base(dbContextOptions) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.HasCharSet("utf8mb4");

        // Aplica as configurações de entidades
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new ChatConfiguration());
        builder.ApplyConfiguration(new MessageConfiguration());
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
}
