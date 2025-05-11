using LiteMessenger.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id).IsRequired().HasMaxLength(100);

        builder.Property(m => m.ChatId).IsRequired().HasMaxLength(100);

        builder.Property(m => m.UserId).IsRequired().HasMaxLength(100);

        builder.Property(m => m.TimeStamp).IsRequired().HasMaxLength(50);

        builder.Property(m => m.Content).IsRequired().HasMaxLength(1000);

        builder
            .HasOne(m => m.Chat)
            .WithMany()
            .HasForeignKey(m => m.ChatId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(m => m.User)
            .WithMany()
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable("Messages");
    }
}
