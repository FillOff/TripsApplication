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
    Domain.Models.Route? Route,
    Guid UserId,
    List<Comment> Comments,
    List<Image> Images);