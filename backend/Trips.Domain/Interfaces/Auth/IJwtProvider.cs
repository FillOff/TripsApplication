using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Trips.Domain.Models;

namespace Trips.Interfaces.Auth;

public interface IJwtProvider
{
    string GenerateToken(User user);
    string? GetUserIdFromClaims(string token);
    string GetToken(HttpContext httpContext);
}