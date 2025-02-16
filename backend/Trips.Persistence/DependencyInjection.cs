using Microsoft.Extensions.DependencyInjection;
using Trips.Interfaces.Repositories;
using Trips.Persistence.Repositories;

namespace Trips.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITripsRepository, TripsRepository>();
        services.AddScoped<IRoutesRepository, RoutesRepository>();
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ICommentsRepository, CommentsRepository>();
        services.AddScoped<IImagesRepository, ImagesRepository>();

        return services;
    }
}
