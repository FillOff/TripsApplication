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
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthController(
        IAuthService usersService,
        IHttpContextAccessor httpContextAccessor)
    {
        _authService = usersService;
        _httpContextAccessor = httpContextAccessor;
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

        var context = _httpContextAccessor.HttpContext;
        context?.Response.Cookies.Append("jwt-token", token);

        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public IActionResult LogOut()
    {
        var context = _httpContextAccessor.HttpContext;
        context?.Response.Cookies.Delete("jwt-token");

        return Ok();
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        return Ok(await _authService.Get());
    }
}
