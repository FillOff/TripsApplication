using Trips.Domain.Models;

namespace Trips.Interfaces.Repositories;

public interface IRoutesRepository
{
    Task<Guid> Add(Guid id, string startPlace, string endPlace, double length, long duration);
    Task<Guid> Delete(Guid id);
    Task<List<Route>> Get();
    Task<Route?> GetById(Guid id);
    Task<Guid> Update(Guid id, string startPlace, string endPlace, double length, long duration);
}