using CarRentalSys.Domain.Core.Rents;
using CarRentalSys.Domain.Core.Users;
using CarRentalSys.Domain.Core.Vehicles;
using CarRentalSys.Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRentalSys.Infrastructure.Configurations;

public sealed class RentConf : IEntityTypeConfiguration<Rent>
{
  public void Configure(EntityTypeBuilder<Rent> builder)
  {
    builder.ToTable("rents");
    builder.HasKey(rent => rent.Identifier);

    builder.OwnsOne(
      rent => rent.DetailPrice,
      priceBuilder =>
      {
        priceBuilder.Property(price => price.Accessories)
            .HasConversion(
            amount => amount.CurrencyCode,
            currencyCode => new Amount(currencyCode,0));

        priceBuilder.Property(price => price.Maintained)
            .HasConversion(
            amount => amount.CurrencyCode,
            currencyCode => new Amount(currencyCode,0));

        priceBuilder.Property(price => price.Use)
            .HasConversion(
            amount => amount.CurrencyCode,
            currencyCode => new Amount(currencyCode,0));
      });

    builder.OwnsOne(
      rent => rent.Range,
    rangeBuilder =>
    {
      rangeBuilder.Property(range => range.From);
      rangeBuilder.Property(range => range.To);
    });

    builder.HasOne<Vehicle>()
      .WithMany()
      .HasForeignKey(rent => rent.VehicleId);

    builder.HasOne<User>()
      .WithMany()
      .HasForeignKey(rent => rent.UserId);
  }
}
