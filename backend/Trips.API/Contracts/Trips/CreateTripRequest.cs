namespace Trips.API.Contracts.Trips;

public record class CreateTripRequest(
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    Guid RouteId);