using Trips.Infrastructure.Services;
using Trips.Interfaces.Auth;

namespace Trips.API.Extensions;

public static class InfrastructureExtensions
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
