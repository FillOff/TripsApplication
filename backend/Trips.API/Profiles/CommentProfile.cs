using AutoMapper;
using Trips.API.Contracts.Comments;
using Trips.Domain.Models;

namespace Trips.API.Profiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, GetCommentResponse>();
    }
}
