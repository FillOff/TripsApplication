using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trips.Domain.Models;

namespace Trips.Persistence.Configurations;

public class TripConfiguration : IEntityTypeConfiguration<Trip>
{
    public void Configure(EntityTypeBuilder<Trip> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .HasOne(t => t.Route)
            .WithOne(r => r.Trip)
            .HasForeignKey<Trip>(t => t.RouteId);

        builder
            .HasOne(t => t.User)
            .WithMany(u => u.Trips)
            .HasForeignKey(t => t.UserId);

        builder
            .HasMany(t => t.Comments)
            .WithOne(c => c.Trip)
            .HasForeignKey(c => c.TripId);

        builder
            .HasMany(t => t.Images)
            .WithOne(i => i.Trip)
            .HasForeignKey(i => i.TripId);

        builder
            .Property(t => t.TripStatus)
            .HasConversion<string>();
    }
}
