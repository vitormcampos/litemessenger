namespace LiteMessenger.Domain.Dtos.User;

public sealed record UserResponse(
    string Id,
    string Email,
    string Name,
    int Status,
    string? ProfilePictureUrl,
    DateTime? RegistrationDate,
    DateTime? LastLoginDate
);
