using LiteMessenger.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Nome da tabela
        builder.ToTable("Users");

        // Chave primária
        builder.HasKey(u => u.Id);

        // Configurações das propriedades
        builder
            .Property(u => u.Id)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .HasCharSet("utf8mb4");

        builder.Property(u => u.Email).HasColumnType("longtext").HasCharSet("utf8mb4");

        builder.Property(u => u.Password).HasColumnType("longtext").HasCharSet("utf8mb4");

        builder.Property(u => u.Name).HasColumnType("longtext").HasCharSet("utf8mb4");

        builder.Property(u => u.Status).IsRequired().HasColumnType("int");

        builder.Property(u => u.ProfilePictureUrl).HasColumnType("longtext").HasCharSet("utf8mb4");

        builder.Property(u => u.RegistrationDate).HasColumnType("datetime(6)");

        builder.Property(u => u.LastLoginDate).HasColumnType("datetime(6)");
    }
}
