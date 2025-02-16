using Microsoft.EntityFrameworkCore;
using Trips.Domain.Enums;
using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Persistence.Databases;

namespace Trips.Persistence.Repositories;

public class TripsRepository : ITripsRepository
{
    private readonly ApplicationDbContext _context;

    public TripsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Trip>> Get()
    {
        return await _context.Trips
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Trip?> GetById(Guid id)
    {
        var trip = await _context.Trips.FindAsync(id);

        return trip;
    }

    public async Task<List<Trip>> GetWithRouteWithImages()
    {
        return await _context.Trips
            .AsNoTracking()
            .Include(t => t.Route)
            .Include(t => t.Images)
            .ToListAsync();
    }

    public async Task<List<Trip>> GetWithRouteWithImagesWithComments()
    {
        return await _context.Trips
            .AsNoTracking()
            .Include(t => t.Route)
            .Include(t => t.Images)
            .Include(t => t.Comments)
            .ToListAsync();
    }

    public async Task<Guid> Add(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        TimeSpan relativeDateTime,
        TripStatus tripStatus,
        Guid routeId,
        Guid userId)
    {
        var trip = new Trip
        {
            Id = id,
            Name = name,
            Description = description,
            StartDateTime = startDateTime,
            EndDateTime = endDateTime,
            RelativeDateTime = relativeDateTime,
            TripStatus = tripStatus,
            RouteId = routeId,
            UserId = userId
        };

        await _context.Trips
            .AddAsync(trip);

        await _context.SaveChangesAsync();

        return trip.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Trips
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<Guid> Update(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime,
        TimeSpan relativeDateTime,
        TripStatus tripStatus)
    {
        await _context.Trips
            .Where(t => t.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(t => t.Name, name)
                .SetProperty(t => t.Description, description)
                .SetProperty(t => t.StartDateTime, startDateTime)
                .SetProperty(t => t.EndDateTime, endDateTime)
                .SetProperty(t => t.RelativeDateTime, relativeDateTime)
                .SetProperty(t => t.TripStatus, tripStatus));

        return id;
    }
}
