using Microsoft.EntityFrameworkCore;
using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Persistence.Databases;

namespace Trips.Persistence.Repositories;

public class ImagesRepository : IImagesRepository
{
    private readonly ApplicationDbContext _context;

    public ImagesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Image>> Get()
    {
        return await _context.Images
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Image?> GetById(Guid id)
    {
        var image = await _context.Images.FindAsync(id);

        return image;
    }

    public async Task<List<Image>> GetWithTrip()
    {
        return await _context.Images
            .AsNoTracking()
            .Include(i => i.Trip)
            .ToListAsync();
    }

    public async Task<Guid> Add(
        Guid id,
        string url,
        string filePath,
        Guid tripId)
    {
        var image = new Image
        {
            Id = id,
            Url = url,
            FilePath = filePath,
            TripId = tripId

        };

        await _context.Images
            .AddAsync(image);

        await _context.SaveChangesAsync();

        return image.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Images
            .Where(i => i.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<Guid> Update(
        Guid id,
        string url,
        string filePath,
        Guid tripId)
    {
        await _context.Images
            .Where(i => i.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(i => i.Url, url)
                .SetProperty(i => i.FilePath, filePath)
                .SetProperty(i => i.TripId, tripId));

        return id;
    }
}
