using LiteMessenger.Domain.Dtos.User;
using LiteMessenger.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace LiteMessenger.Api.Controllers;

[Route("api/account")]
[ApiController]
public class Account(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task Register([FromBody] UserRegister userRegister)
    {
        await userService.Register(userRegister);
    }
}
