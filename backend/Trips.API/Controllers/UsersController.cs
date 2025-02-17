using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Routes;
using Trips.API.Contracts.Users;
using Trips.Domain.Models;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UsersController(
        IUsersService usersService,
        IHttpContextAccessor httpContextAccessor)
    {
        _usersService = usersService;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest user)
    {
        await _usersService.Register(user.Name, user.Email, user.Password);

        return Ok();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginUserRequest user)
    {
        var token = await _usersService.Login(user.Email, user.Password);

        var context = _httpContextAccessor.HttpContext;
        context?.Response.Cookies.Append("jwt-token", token);

        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        return Ok(await _usersService.Get());
    }
}
