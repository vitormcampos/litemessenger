using LiteMessenger.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ChatConfiguration : IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).IsRequired().HasMaxLength(100);

        builder.Property(c => c.Name).IsRequired().HasMaxLength(200);

        builder.ToTable("Chats");
    }
}
