namespace Trips.API.Contracts.Routes;

public record class UpdateRoutesRequest(
    Guid Id,
    string StartPlace,
    string EndPlace,
    double Length,
    TimeOnly Duration);