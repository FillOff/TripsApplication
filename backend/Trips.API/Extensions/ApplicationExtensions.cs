using Trips.Application.Services;
using Trips.Interfaces.Services;

namespace Trips.API.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITripsService, TripsService>();
        services.AddScoped<IRoutesService, RoutesService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICommentsService, CommentsService>();
        services.AddScoped<IImagesService, ImagesService>();

        return services;
    }
}
