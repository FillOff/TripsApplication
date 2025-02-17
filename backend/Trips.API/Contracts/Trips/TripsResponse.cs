using Trips.API.Contracts.Comments;
using Trips.API.Contracts.Routes;
using Trips.Domain.Enums;
using Trips.Domain.Models;

namespace Trips.API.Contracts.Trips;

public record class TripsResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    TimeSpan RelativeDateTime,
    TripStatus TripStatus,
    Guid RouteId,
    RoutesResponse? Route,
    Guid UserId,
    List<CommentsResponse> Comments,
    List<Image> Images);