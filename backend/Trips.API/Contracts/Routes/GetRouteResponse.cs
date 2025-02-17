namespace Trips.API.Contracts.Routes;

public record class GetRouteResponse(
    Guid Id,
    string StartPlace,
    string EndPlace,
    double Length,
    TimeOnly Duration,
    Guid TripId);