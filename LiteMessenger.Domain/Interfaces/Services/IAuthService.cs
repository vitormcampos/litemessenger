using LiteMessenger.Domain.Models;

namespace LiteMessenger.Domain.Interfaces.Services;

public interface IAuthService
{
    string GenerateJwtToken(User user);
}
