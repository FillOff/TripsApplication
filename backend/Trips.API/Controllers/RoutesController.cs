using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Routes;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RoutesController : ControllerBase
{
    private readonly IRoutesService _routesService;
    public RoutesController(IRoutesService routesService)
    {
        _routesService = routesService;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoutesResponse>>> GetRoutes()
    {
        var response = (await _routesService.GetRoutesAsync())
            .Select(r => new RoutesResponse(
                r.Id,
                r.StartPlace,
                r.EndPlace,
                r.Length,
                r.Duration))
            .ToList();

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateRoute([FromBody] CreateRoutesRequest route)
    {
        Guid id = await _routesService.CreateRouteAsync(
            route.StartPlace,
            route.EndPlace,
            route.Length,
            route.Duration);

        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> UpdateRoute([FromBody] UpdateRoutesRequest route)
    {
        Guid id = await _routesService.UpdateRouteAsync(
            route.Id,
            route.StartPlace,
            route.EndPlace,
            route.Length,
            route.Duration);

        return Ok(id);
    }

    [HttpDelete]
    public async Task<ActionResult<Guid>> DeleteRoute(Guid id)
    {
        return Ok(await _routesService.DeleteRouteAsync(id));
    }
}
