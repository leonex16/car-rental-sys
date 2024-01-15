using CarRentalSys.Domain.Core.Rents;
using CarRentalSys.Domain.Core.Reviews;
using CarRentalSys.Domain.Core.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSys.Infrastructure.Configurations;

public sealed class ReviewConf : IEntityTypeConfiguration<Review>
{
  public void Configure(EntityTypeBuilder<Review> builder)
  {
    builder.ToTable("reviews");
    builder.HasKey(rent => rent.Identifier);

    builder.Property(review => review.Comment);
    builder.Property(review => review.CreatedAt);
    builder.Property(review => review.Rating);

    builder.HasOne<Vehicle>()
      .WithMany()
      .HasForeignKey(rent => rent.VehicleId);

    builder.HasOne<Rent>()
      .WithMany()
      .HasForeignKey(review => review.RentId);
  }
}
