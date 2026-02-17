using System.IdentityModel.Tokens.Jwt;
using LiteMessenger.Domain.Dtos.User;
using LiteMessenger.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest userLogin)
    {
        var token = await userService.Login(userLogin);
        if (token == null)
        {
            return Unauthorized();
        }
        return Ok(token);
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var user = await userService.GetCurrentUser(userId);
        if (user is null)
        {
            return NotFound();
        }

        return Ok(user);
    }
}
