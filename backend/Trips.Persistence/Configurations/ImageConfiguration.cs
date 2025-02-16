using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trips.Domain.Models;

namespace Trips.Persistence.Configurations;

public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.HasKey(i => i.Id);

        builder
            .HasOne(i => i.Trip)
            .WithMany(t => t.Images)
            .HasForeignKey(i => i.TripId);
    }
}
