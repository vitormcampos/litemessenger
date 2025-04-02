using LiteMessenger.Domain.Dtos.User;
using LiteMessenger.Domain.Interfaces.Services;
using LiteMessenger.Domain.Models;

namespace LiteMessenger.Application.Services;

public class UserService : BaseService<User>, IUserService
{
    public UserService(LiteMessengerContext context)
        : base(context) { }

    public Task Login()
    {
        throw new NotImplementedException();
    }

    public Task Logout()
    {
        throw new NotImplementedException();
    }

    public async Task Register(UserRegister userRegister)
    {
        var (userName, email, password, _) = userRegister;

        // TODO: Trabalar com Exceptions customizadas
        if (!userRegister.PasswordIsValid())
        {
            throw new Exception("Senha informada é inválida");
        }

        // TODO: Encriptar password
        var encryptedPassword = password;

        var user = new User(
            Id: Guid.NewGuid().ToString(),
            Email: email,
            Password: encryptedPassword,
            Name: userName,
            Status: 1,
            ProfilePictureUrl: null,
            RegistrationDate: DateTime.Now,
            LastLoginDate: null
        );

        await CreateAsync(user);
    }
}
