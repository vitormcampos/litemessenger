using LiteMessenger.Domain.Dtos.User;
using LiteMessenger.Domain.Models;

namespace LiteMessenger.Domain.Interfaces.Services;

public interface IUserService : IBaseService<User>
{
    Task<string> Login(LoginRequest loginRequest);
    Task Register(UserRegister userRegister);
}
