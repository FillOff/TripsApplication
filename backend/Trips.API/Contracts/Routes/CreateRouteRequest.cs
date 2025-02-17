namespace Trips.API.Contracts.Routes;

public record class CreateRouteRequest(
    string StartPlace,
    string EndPlace,
    double Length,
    TimeOnly Duration);