namespace Trips.API.Contracts.Routes;

public record class UpdateRouteRequest(
    Guid Id,
    string StartPlace,
    string EndPlace,
    double Length,
    TimeOnly Duration);