using AutoMapper;
using Trips.API.Contracts.Images;
using Trips.Domain.Models;

namespace Trips.API.Profiles;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<Image, GetImageResponse>();
    }
}
