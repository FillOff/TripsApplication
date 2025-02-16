using Trips.Domain.Models;

namespace Trips.Interfaces.Services;

public interface IUsersService
{
    Task<Guid> DeleteUserAsync(Guid id);
    Task<Guid> UpdateUserAsync(Guid id, string name, string email, string passwordHash);
    Task Register(string name, string email, string password);
    Task<string> Login(string email, string password);
    Task<List<User>> Get();
}