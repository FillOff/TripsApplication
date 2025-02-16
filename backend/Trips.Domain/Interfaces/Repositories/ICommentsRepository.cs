using Trips.Domain.Models;

namespace Trips.Interfaces.Repositories;

public interface ICommentsRepository
{
    Task<Guid> Add(Guid id, string content, Guid userId, Guid tripId);
    Task<Guid> Delete(Guid id);
    Task<List<Comment>> Get();
    Task<Guid> Update(Guid id, string content, Guid userId, Guid tripId);
}