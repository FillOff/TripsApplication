using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Trips.API.Contracts.Trips;
using Trips.Domain.Models;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripsService;
    private readonly IMapper _mapper;

    public TripsController(
        ITripsService tripsService,
        IMapper mapper)
    {
        _tripsService = tripsService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetTripResponse>>> GetTripsWithRouteWithImagesWithComments()
    {
        var trips = await _tripsService.GetTripsWithRouteWithImagesWithCommentsAsync();
        var response = _mapper.Map<List<GetTripResponse>>(trips);
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTrip([FromBody] CreateTripRequest trip)
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
    public async Task<ActionResult<Guid>> UpdateTrip([FromBody] UpdateTripRequest trip)
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
