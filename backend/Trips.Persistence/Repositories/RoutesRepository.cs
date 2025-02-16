using Microsoft.EntityFrameworkCore;
using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Persistence.Databases;

namespace Trips.Persistence.Repositories;

public class RoutesRepository : IRoutesRepository
{
    private readonly ApplicationDbContext _context;

    public RoutesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Route>> Get()
    {
        return await _context.Routes
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Route?> GetById(Guid id)
    {
        var route = await _context.Routes.FindAsync(id);

        return route;
    }

    public async Task<List<Route>> GetWithTrip()
    {
        return await _context.Routes
            .AsNoTracking()
            .Include(r => r.Trip)
            .ToListAsync();
    }

    public async Task<Guid> Add(
        Guid id,
        string startPlace,
        string endPlace,
        double length,
        TimeOnly duration,
        Guid tripId)
    {
        var route = new Route
        {
            Id = id,
            StartPlace = startPlace,
            EndPlace = endPlace,
            Length = length,
            Duration = duration,
            TripId = tripId

        };

        await _context.Routes
            .AddAsync(route);

        await _context.SaveChangesAsync();

        return route.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Routes
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<Guid> Update(
        Guid id,
        string startPlace,
        string endPlace,
        double length,
        TimeOnly duration,
        Guid tripId)
    {
        await _context.Routes
            .Where(r => r.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(r => r.StartPlace, startPlace)
                .SetProperty(r => r.EndPlace, endPlace)
                .SetProperty(r => r.Length, length)
                .SetProperty(r => r.Duration, duration)
                .SetProperty(r => r.TripId, tripId));

        return id;
    }
}
