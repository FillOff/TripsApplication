using Microsoft.EntityFrameworkCore;
using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Persistence.Databases;

namespace Trips.Persistence.Repositories;

public class CommentsRepository : ICommentsRepository
{
    private readonly ApplicationDbContext _context;

    public CommentsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Comment>> Get()
    {
        return await _context.Comments
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Guid> Add(
        Guid id,
        string content,
        Guid userId,
        Guid tripId)
    {
        var comment = new Comment
        {
            Id = id,
            Content = content,
            UserId = userId,
            TripId = tripId
        };

        await _context.Comments
            .AddAsync(comment);

        await _context.SaveChangesAsync();

        return comment.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Comments
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<Guid> Update(
        Guid id,
        string content,
        Guid userId,
        Guid tripId)
    {
        await _context.Comments
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(c => c.Content, content)
                .SetProperty(c => c.UserId, userId)
                .SetProperty(c => c.TripId, tripId));

        return id;
    }
}
