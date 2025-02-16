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
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("/register")]
    public async Task<IActionResult> Register([FromBody] RegisterUsersRequest user)
    {
        await _usersService.Register(user.Name, user.Email, user.Password);

        return Ok();
    }

    [HttpPost("/login")]
    public async Task<IActionResult> Login([FromBody] LoginUsersRequest user)
    {
        var token = await _usersService.Login(user.Email, user.Password);

        return Ok(token);
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        return Ok(await _usersService.Get());
    }
}
