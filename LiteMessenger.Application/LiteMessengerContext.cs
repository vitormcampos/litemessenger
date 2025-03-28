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
    }

    public DbSet<User> Users { get; set; }
}
