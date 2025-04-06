using LiteMessenger.Domain.Dtos.User;
using LiteMessenger.Domain.Interfaces.Services;
using LiteMessenger.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LiteMessenger.Application.Services;

public class UserService : BaseService<User>, IUserService
{
    public readonly IAuthService authService;

    public UserService(LiteMessengerContext context, IAuthService authService)
        : base(context)
    {
        this.authService = authService;
    }

    public async Task<string> Login(LoginRequest loginRequest)
    {
        var user = await context.Users.FirstOrDefaultAsync(u =>
            u.Email == loginRequest.Email && u.Password == loginRequest.Password
        );

        if (user is not null)
        {
            return authService.GenerateJwtToken(user);
        }

        throw new Exception("Usuário ou senha inválidos.");
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
