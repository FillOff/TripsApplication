namespace Trips.API.Contracts.Trips;

public record class CreateTripsRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    Guid RouteId,
    Guid UserId);