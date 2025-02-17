using AutoMapper;
using Trips.API.Contracts.Trips;
using Trips.Domain.Models;

namespace Trips.API.Profiles;

public class TripProfile : Profile
{
    public TripProfile()
    {
        CreateMap<Trip, TripsResponse>()
            .ForMember(dest => dest.Route, opt => opt.MapFrom(src => src.Route))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));
    }
}
