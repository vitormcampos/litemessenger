using LiteMessenger.Domain.Dtos.User;
using LiteMessenger.Domain.Models;

namespace LiteMessenger.Domain.Interfaces.Services;

public interface IUserService : IBaseService<User>
{
    Task Login();
    Task Logout();
    Task Register(UserRegister userRegister);
}
