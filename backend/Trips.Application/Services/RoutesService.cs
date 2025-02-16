using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Interfaces.Services;

namespace Trips.Application.Services;

public class RoutesService : IRoutesService
{
    private readonly IRoutesRepository _routesRepository;

    public RoutesService(IRoutesRepository routesRepository)
    {
        _routesRepository = routesRepository;
    }

    public async Task<List<Route>> GetRoutesAsync()
    {
        return await _routesRepository.Get();
    }

    public async Task<Guid> CreateRouteAsync(
        string startPlace,
        string endPlace,
        double length,
        TimeOnly duration)
    {
        return await _routesRepository.Add(
            Guid.NewGuid(),
            startPlace,
            endPlace,
            length,
            duration);
    }

    public async Task<Guid> UpdateRouteAsync(
        Guid id,
        string startPlace,
        string endPlace,
        double length,
        TimeOnly duration)
    {
        return await _routesRepository.Update(
            id,
            startPlace,
            endPlace,
            length,
            duration);
    }

    public async Task<Guid> DeleteRouteAsync(Guid id)
    {
        return await _routesRepository.Delete(id);
    }
}
