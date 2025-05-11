using LiteMessenger.Domain.Dtos.User;
using LiteMessenger.Domain.Models;

namespace LiteMessenger.Domain.Interfaces.Services;

public interface IUserService
{
    Task<string> Login(LoginRequest loginRequest);
    Task Register(UserRegister userRegister);
    Task ChangeStatusTo(string UserId, int Status);
}
