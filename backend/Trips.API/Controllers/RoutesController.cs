using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Routes;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[Authorize]
[ApiController]
[Route("/api/[controller]")]
public class RoutesController : ControllerBase
{
    private readonly IRoutesService _routesService;
    private readonly IMapper _mapper;

    public RoutesController(
        IRoutesService routesService,
        IMapper mapper)
    {
        _routesService = routesService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetRouteResponse>>> GetRoutes()
    {
        var routes = await _routesService.GetRoutesAsync();
        var response = _mapper.Map<List<GetRouteResponse>>(routes);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateRoute([FromBody] CreateRouteRequest route)
    {
        Guid id = await _routesService.CreateRouteAsync(
            route.StartPlace,
            route.EndPlace,
            route.Length,
            route.Duration);

        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateRoute(
        [FromRoute] Guid id,
        [FromBody] UpdateRouteRequest route)
    {
        id = await _routesService.UpdateRouteAsync(
            id,
            route.StartPlace,
            route.EndPlace,
            route.Length,
            route.Duration);

        return Ok(id);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteRoute([FromRoute] Guid id)
    {
        return Ok(await _routesService.DeleteRouteAsync(id));
    }
}
