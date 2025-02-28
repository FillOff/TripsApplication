using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Users;
using Trips.Domain.Models;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(
        IAuthService usersService)
    {
        _authService = usersService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest user)
    {
        await _authService.Register(user.Name, user.Email, user.Password);

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest user)
    {
        var token = await _authService.Login(user.Email, user.Password);

        return Ok(token);
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult GetMe()
    {
        return Ok();
    }
}
