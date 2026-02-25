using LiteMessenger.Domain.Dtos.User;
using LiteMessenger.Domain.Exceptions;
using LiteMessenger.Domain.Interfaces.Services;
using LiteMessenger.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LiteMessenger.Application.Services;

public class UserService(LiteMessengerContext context, IAuthService authService) : IUserService
{
    private readonly LiteMessengerContext context = context;
    private readonly IAuthService authService = authService;

    public async Task<string> Login(LoginRequest loginRequest)
    {
        var user = await context
            .Users.AsNoTracking()
            .FirstOrDefaultAsync(u =>
                u.Email == loginRequest.Email && u.Password == loginRequest.Password
            );

        if (user is not null)
        {
            return authService.GenerateJwtToken(user);
        }

        throw new RegisterNotFoundException("Usuário ou senha inválidos.");
    }

    public async Task Register(UserRegister userRegister)
    {
        var (userName, email, password, _) = userRegister;

        var existingUser = await context
            .Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
        if (existingUser is not null)
        {
            throw new ValidationException("Email já cadastrado.");
        }

        if (!userRegister.PasswordIsValid())
        {
            throw new ValidationException("Senha informada é inválida");
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

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }

    public async Task ChangeStatusTo(string UserId, int Status)
    {
        var user = await context
            .Users.AsNoTracking()
            .FirstOrDefaultAsync(user => user.Id == UserId);

        if (user is null)
            return;

        user.UpdateStatus(Status);

        context.Users.Update(user);

        await context.SaveChangesAsync();
    }

    public async Task<UserResponse?> GetCurrentUser(string userId)
    {
        var user = await context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == userId);

        if (user is null)
            return null;

        return new UserResponse(
            user.Id!,
            user.Email!,
            user.Name!,
            user.Status,
            user.ProfilePictureUrl,
            user.RegistrationDate,
            user.LastLoginDate
        );
    }

    public async Task<List<UserResponse>> GetOnlineUsers()
    {
        var onlineUsers = await context
            .Users.AsNoTracking()
            .Where(u => u.Status == 1)
            .Select(u => new UserResponse(
                u.Id!,
                u.Email!,
                u.Name!,
                u.Status,
                u.ProfilePictureUrl,
                u.RegistrationDate,
                u.LastLoginDate
            ))
            .ToListAsync();

        return onlineUsers;
    }
}
