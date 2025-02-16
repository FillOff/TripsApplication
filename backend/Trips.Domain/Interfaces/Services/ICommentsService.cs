using Trips.Domain.Models;

namespace Trips.Interfaces.Services;

public interface ICommentsService
{
    Task<Guid> CreateCommentAsync(string content, Guid userId, Guid tripId);
    Task<Guid> DeleteCommentAsync(Guid id);
    Task<List<Comment>> GetCommentsAsync();
    Task<Guid> UpdateCommentAsync(Guid id, string content, Guid userId, Guid tripId);
}