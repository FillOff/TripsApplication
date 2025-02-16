using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Trips.Domain.Models;
using Trips.Persistence.Configurations;

namespace Trips.Persistence.Databases;

public class UsersDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public UsersDbContext(IConfiguration configuration)
    {
        _configuration = configuration;

        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString(nameof(UsersDbContext)));
    }
}
