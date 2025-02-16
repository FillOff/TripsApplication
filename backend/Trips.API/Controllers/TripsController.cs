using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Trips;
using Trips.Domain.Models;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripsService;
    public TripsController(ITripsService tripsService)
    {
        _tripsService = tripsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<TripsResponse>>> GetTripsWithRouteWithImagesWithComments()
    {
        var response = (await _tripsService.GetTripsWithRouteWithImagesWithCommentsAsync())
            .Select(t => new TripsResponse(
                t.Id,
                t.Name,
                t.Description,
                t.StartDateTime,
                t.EndDateTime,
                t.RelativeDateTime,
                t.TripStatus,
                t.RouteId,
                t.Route,
                t.UserId,
                t.Comments,
                t.Images))
            .ToList();
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTrip([FromBody] CreateTripsRequest trip)
    {
        Guid id = await _tripsService.CreateTripAsync(
            trip.Name,
            trip.Description,
            trip.StartDateTime,
            trip.EndDateTime,
            trip.RouteId,
            trip.UserId);

        return Ok(id);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> UpdateTrip([FromBody] UpdateTripsRequest trip)
    {
        Guid id = await _tripsService.UpdateTripAsync(
            trip.Id,
            trip.Name,
            trip.Description,
            trip.StartDateTime,
            trip.EndDateTime,
            trip.RelativeDateTime,
            trip.TripStatus);

        return Ok(id);
    }

    [HttpDelete]
    public async Task<ActionResult<Guid>> DeleteTrip(Guid id)
    {
        return Ok(await _tripsService.DeleteTripAsync(id));
    }
}
