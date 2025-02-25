using Trips.Domain.Models;

namespace Trips.Interfaces.Services;

public interface IRoutesService
{
    Task<Guid> CreateRouteAsync(string startPlace, string endPlace, double length, long duration);
    Task<Guid> DeleteRouteAsync(Guid id);
    Task<List<Route>> GetRoutesAsync();
    Task<Guid> UpdateRouteAsync(Guid id, string startPlace, string endPlace, double length, long duration);
}