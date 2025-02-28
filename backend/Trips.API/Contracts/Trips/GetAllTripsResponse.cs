using Trips.API.Contracts.Routes;
using Trips.API.Contracts.Users;

namespace Trips.API.Contracts.Trips;

public record class GetAllTripsResponse(
    Guid Id,
    string Name,
    string Description,
    GetRouteResponse Route,
    GetUserResponse User);
