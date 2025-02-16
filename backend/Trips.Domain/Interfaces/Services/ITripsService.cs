using Trips.Domain.Enums;
using Trips.Domain.Models;

namespace Trips.Interfaces.Services;

public interface ITripsService
{
    Task<List<Trip>> GetTripsWithRouteWithImagesWithCommentsAsync();
    Task<Guid> CreateTripAsync(string name, string description, DateTime startDateTime, DateTime endDateTime, Guid routeId, Guid userId);
    Task<Guid> UpdateTripAsync(Guid id, string name, string description, DateTime startDateTime, DateTime endDateTime, TimeSpan relativeDateTime, TripStatus tripStatus);
    Task<Guid> DeleteTripAsync(Guid id);
}