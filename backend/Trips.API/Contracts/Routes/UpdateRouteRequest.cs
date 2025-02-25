namespace Trips.API.Contracts.Routes;

public record class UpdateRouteRequest(
    string StartPlace,
    string EndPlace,
    double Length,
    long Duration);