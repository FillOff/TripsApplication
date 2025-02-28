using AutoMapper;
using Trips.API.Contracts.Users;
using Trips.Domain.Models;

namespace Trips.API.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, GetUserResponse>();
    }
}
