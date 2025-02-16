using Microsoft.Extensions.DependencyInjection;
using Trips.Application.Services;
using Trips.Interfaces.Services;

namespace Trips.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITripsService, TripsService>();
        services.AddScoped<IRoutesService, RoutesService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<ICommentsService, CommentsService>();
        services.AddScoped<IImagesService, ImagesService>();

        return services;
    }
}
