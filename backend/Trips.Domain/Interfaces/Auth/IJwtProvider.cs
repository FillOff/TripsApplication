using Trips.Domain.Models;

namespace Trips.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
    string? GetUserIdFromClaims(string token);
}