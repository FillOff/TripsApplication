using Trips.Domain.Models;

namespace Trips.Interfaces.Repositories;

public interface IUsersRepository
{
    Task<Guid> Add(Guid id, string name, string email, string passwordHash);
    Task<Guid> Delete(Guid id);
    Task<List<User>> Get();
    Task<Guid> Update(Guid id, string name, string email, string passwordHash);
}