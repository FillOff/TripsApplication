using AutoMapper;
using Trips.API.Contracts.Routes;

namespace Trips.API.Profiles;

public class RouteProfile : Profile
{
    public RouteProfile()
    {
        CreateMap<Domain.Models.Route, GetRouteResponse>();
    }
}
