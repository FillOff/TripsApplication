using Trips.Interfaces.Repositories;
using Trips.Persistence.Databases;
using Trips.Persistence.Repositories;

namespace Trips.API.Extensions;

public static class PersistenceExtensions
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

    public static IServiceCollection AddDbContexts(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();

        return services;
    }
}
