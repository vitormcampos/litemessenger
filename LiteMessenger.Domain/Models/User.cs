namespace LiteMessenger.Domain.Models;

public sealed record User(
    string? Id,
    string? Email,
    string? Password,
    string? Name,
    int Status,
    string? ProfilePictureUrl,
    DateTime? RegistrationDate,
    DateTime? LastLoginDate
);
