using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trips.API.Contracts.Trips;
using Trips.Domain.Models;
using Trips.Interfaces.Auth;
using Trips.Interfaces.Services;

namespace Trips.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TripsController : ControllerBase
{
    private readonly ITripsService _tripsService;
    private readonly IRoutesService _routesService;
    private readonly ICommentsService _commentsService;
    private readonly IImagesService _imagesService;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IJwtProvider _jwtProvider;
    private readonly IMapper _mapper;

    public TripsController(
        ITripsService tripsService,
        IRoutesService routesService,
        ICommentsService commentsService,
        IImagesService imagesService,
        IHttpContextAccessor contextAccessor,
        IJwtProvider jwtProvider,
        IMapper mapper)
    {
        _tripsService = tripsService;
        _routesService = routesService;
        _commentsService = commentsService;
        _imagesService = imagesService;
        _contextAccessor = contextAccessor;
        _jwtProvider = jwtProvider;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetTripResponse>>> GetTripsWithRouteWithImagesWithComments()
    {
        var httpContext = _contextAccessor.HttpContext;
        var token = _jwtProvider.GetToken(httpContext!);
        string? userIdString = _jwtProvider.GetUserIdFromClaims(token);

        if (userIdString == null)
            return Unauthorized();

        Guid userId = Guid.Parse(userIdString);
        var trips = await _tripsService.GetTripsWithRouteWithImagesWithCommentsAsync(userId);
        var response = _mapper.Map<List<GetTripResponse>>(trips);

        return Ok(response);
    }

    [HttpGet("history")]
    public async Task<ActionResult<List<GetTripResponse>>> GetHistoryTrips()
    {
        var httpContext = _contextAccessor.HttpContext;
        var token = _jwtProvider.GetToken(httpContext!);
        string? userIdString = _jwtProvider.GetUserIdFromClaims(token);

        if (userIdString == null)
            return Unauthorized();

        Guid userId = Guid.Parse(userIdString);
        var trips = await _tripsService.GetHistoryTripsWithRouteWithImagesWithCommentsAsync(userId);
        var response = _mapper.Map<List<GetTripResponse>>(trips);

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetTripResponse>> GetTrip(Guid id)
    {
        var trip = await _tripsService.GetTripWithRouteWithImagesWithCommentsAsync(id);
        var response = _mapper.Map<GetTripResponse>(trip);

        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateTrip([FromBody] CreateTripRequest trip)
    {
        var httpContext = _contextAccessor.HttpContext;
        var token = _jwtProvider.GetToken(httpContext!);
        string? userIdString = _jwtProvider.GetUserIdFromClaims(token);

        if (userIdString == null)
            return Unauthorized();

        Guid userId = Guid.Parse(userIdString);
        Guid id = await _tripsService.CreateTripAsync(
            trip.Name,
            trip.Description,
            trip.StartDateTime,
            trip.EndDateTime,
            trip.RouteId,
            userId);

        return Ok(id);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateTrip(
        [FromRoute] Guid id,
        [FromBody] UpdateTripRequest trip)
    {
        id = await _tripsService.UpdateTripAsync(
            id,
            trip.Name,
            trip.Description,
            trip.StartDateTime,
            trip.EndDateTime,
            trip.RelativeDateTime,
            trip.TripStatus);

        return Ok(id);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteTrip([FromRoute] Guid id)
    {
        var trip = await _tripsService.GetTripWithRouteWithImagesWithCommentsAsync(id);

        if (trip == null)
            return NotFound();

        await _routesService.DeleteRouteAsync(trip.RouteId);
        trip.Comments.ForEach(async c =>
            await _commentsService.DeleteCommentAsync(c.Id));
        trip.Images.ForEach(async i =>
            await _imagesService.DeleteImageAsync(i.Id));

        return Ok(await _tripsService.DeleteTripAsync(id));
    }

    [HttpGet("all")]
    public async Task<ActionResult<List<GetAllTripsResponse>>> GetAllTrips()
    {
        var trips = await _tripsService.GetTripsWithUsersWithRouteAsync();
        var response = _mapper.Map<List<GetAllTripsResponse>>(trips);

        return Ok(response);
    }
}
