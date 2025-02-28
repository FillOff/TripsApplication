using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Trips.Domain.Models;
using Trips.Interfaces.Auth;

namespace Trips.Infrastructure.Services;

public class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _options;
    public JwtProvider(IConfiguration configuration)
    {
        _options = new JwtOptions();
        configuration.GetSection(nameof(JwtOptions)).Bind(_options);
    }

    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
            SecurityAlgorithms.HmacSha256);

        Claim[] claims = [new("userId", user.Id.ToString())];

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: signingCredentials,
            expires: DateTime.UtcNow.AddDays(_options.ExpiresDays)
        );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }

    public string? GetUserIdFromClaims(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId");

        if (userIdClaim == null)
            return null;

        return userIdClaim.Value;
    }

    public string GetToken(HttpContext httpContext)
    {
        var authHeader = httpContext?.Request.Headers["Authorization"].ToString();
        if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith("Bearer "))
        {
            throw new Exception("User unauthorized");
        }

        var token = authHeader.Substring("Bearer ".Length).Trim();

        return token;
    }
}
