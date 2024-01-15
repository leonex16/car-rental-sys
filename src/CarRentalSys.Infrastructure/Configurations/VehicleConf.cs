using CarRentalSys.Domain.Core.Vehicles;
using CarRentalSys.Domain.Core.Vehicles.ValueObjects;
using CarRentalSys.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSys.Infrastructure.Configurations;

public sealed class VehicleConf : IEntityTypeConfiguration<Vehicle>
{
  public void Configure(EntityTypeBuilder<Vehicle> builder)
  {
    builder.ToTable("vehicles");
    builder.HasKey(vehicle => vehicle.Identifier);

    builder.OwnsOne<Address>(vehicle => vehicle.Address);

    builder.Property(vehicle => vehicle.Model)
      .HasMaxLength(100);

    builder.Property(vehicle => vehicle.Vin)
      .HasMaxLength(20);

    builder.OwnsOne<Amount>(
      vehicle => vehicle.PricePerDay,
      priceBuilder =>
      {
        priceBuilder.Property(price => price.CurrencyCode);
        priceBuilder.Property(price => price.Value);
      });

    builder.OwnsOne<Amount>(
      vehicle => vehicle.Maintained,
      priceBuilder =>
      {
        priceBuilder.Property(price => price.CurrencyCode);
        priceBuilder.Property(price => price.Value);
      });
  }
}
