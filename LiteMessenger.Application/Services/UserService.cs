using LiteMessenger.Domain.Models;

namespace LiteMessenger.Application.Services;

public class UserService : BaseService<User>
{
    public UserService(LiteMessengerContext context)
        : base(context) { }
}
