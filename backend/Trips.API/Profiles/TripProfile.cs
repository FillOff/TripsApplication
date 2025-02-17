using AutoMapper;
using Trips.API.Contracts.Trips;
using Trips.Domain.Models;

namespace Trips.API.Profiles;

public class TripProfile : Profile
{
    public TripProfile()
    {
        CreateMap<Trip, GetTripResponse>();
    }
}
