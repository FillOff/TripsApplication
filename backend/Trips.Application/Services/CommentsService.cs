using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Interfaces.Services;

namespace Trips.Application.Services;

public class CommentsService : ICommentsService
{
    private readonly ICommentsRepository _commentsRepository;

    public CommentsService(ICommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    public async Task<List<Comment>> GetCommentsAsync()
    {
        return await _commentsRepository.Get();
    }

    public async Task<Guid> CreateCommentAsync(
        string content,
        Guid userId,
        Guid tripId)
    {
        return await _commentsRepository.Add(
            Guid.NewGuid(),
            content,
            userId,
            tripId);
    }

    public async Task<Guid> UpdateCommentAsync(
        Guid id,
        string content,
        Guid userId,
        Guid tripId)
    {
        return await _commentsRepository.Update(
            id,
            content,
            userId,
            tripId);
    }

    public async Task<Guid> DeleteCommentAsync(Guid id)
    {
        return await _commentsRepository.Delete(id);
    }
}
