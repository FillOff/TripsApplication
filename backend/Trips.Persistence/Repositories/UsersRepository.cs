using Microsoft.EntityFrameworkCore;
using Trips.Domain.Models;
using Trips.Interfaces.Repositories;
using Trips.Persistence.Databases;

namespace Trips.Persistence.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _context;

    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> Get()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetById(Guid id)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Guid> Add(
        Guid id,
        string name,
        string email,
        string passwordHash)
    {
        var user = new User
        {
            Id = id,
            Name = name,
            Email = email,
            PasswordHash = passwordHash,
        };

        await _context.Users
            .AddAsync(user);

        await _context.SaveChangesAsync();

        return user.Id;
    }

    public async Task<Guid> Delete(Guid id)
    {
        await _context.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }

    public async Task<Guid> Update(
        Guid id,
        string name,
        string email,
        string passwordHash)
    {
        await _context.Users
            .Where(u => u.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Name, name)
                .SetProperty(u => u.Email, email)
                .SetProperty(u => u.PasswordHash, passwordHash));

        return id;
    }
}
