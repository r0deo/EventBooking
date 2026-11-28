using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EventBooking.Api.Entities;
 
namespace EventBooking.Api.Infrastructure.Persistence.Configurations;



public class SeatConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.Property(s => s.Label).HasMaxLength(10).IsRequired();
        builder.HasIndex(s => new {s.Label, s.VenueId}).IsUnique();
    }
}