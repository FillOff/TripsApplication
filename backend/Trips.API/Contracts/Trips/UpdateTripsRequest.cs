using Trips.Domain.Enums;

namespace Trips.API.Contracts.Trips;

public record class UpdateTripsRequest(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    TimeSpan RelativeDateTime,
    TripStatus TripStatus,
    Guid RouteId,
    Guid UserId);