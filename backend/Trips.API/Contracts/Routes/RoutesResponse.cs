namespace Trips.API.Contracts.Routes;

public record class RoutesResponse(
    Guid Id,
    string StartPlace,
    string EndPlace,
    double Length,
    TimeOnly Duration);