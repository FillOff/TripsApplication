using Trips.Domain.Enums;
using Trips.Domain.Models;

namespace Trips.Interfaces.Repositories;

public interface ITripsRepository
{
    Task<Guid> Add(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime relativeDateTime, TripStatus tripStatus, Guid routeId, Guid userId);
    Task<Guid> Delete(Guid id);
    Task<List<Trip>> Get();
    Task<Trip?> GetById(Guid id);
    Task<List<Trip>> GetWithRouteWithImages();
    Task<List<Trip>> GetWithRouteWithImagesWithComments();
    Task<Guid> Update(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, DateTime relativeDateTime, TripStatus tripStatus, Guid routeId, Guid userId);
}