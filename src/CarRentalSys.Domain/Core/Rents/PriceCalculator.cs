using CarRentalSys.Domain.Core.Rents.ValueObjects;
using CarRentalSys.Domain.Core.Vehicles;
using CarRentalSys.Domain.Shared.Enums;
using CarRentalSys.Domain.Shared.ValueObjects;

namespace CarRentalSys.Domain.Core.Rents;

public static class PriceCalculator
{
  public static DetailPrice Calculator(Vehicle vehicle, DateRange range)
  {
    var currencyCode = vehicle.PricePerDay.CurrencyCode;
    var pricePerDay = vehicle.PricePerDay.Value;

    var pricePerUse = GetPricePerUse(pricePerDay, range);
    var pricePerAccessories = GetPricePerAccessories(pricePerDay, vehicle.Accessories);
    var priceMaintained = GetPriceMaintained(pricePerDay, vehicle.Maintained);


    return new DetailPrice(
      new Amount(currencyCode, pricePerUse),
      new Amount(currencyCode, pricePerAccessories),
      new Amount(currencyCode, priceMaintained)
    );
  }

  private static decimal GetPricePerUse(decimal pricePerDay, DateRange range)
  {
    var daysOfUse = range.DiffDays;
    var pricePerUse = pricePerDay * daysOfUse;

    return pricePerUse;
  }

  private static decimal GetPricePerAccessories(decimal pricePerDay, List<Accessory> accessories)
  {
    var accessoriesCharge = accessories.Aggregate(0m, (acc, accessory) => acc + accessory switch
    {
      Accessory.Ac => 2m,
      Accessory.Maps => 1m,
      Accessory.Wifi => 2m,
      Accessory.AndroidCar or Accessory.AppleCar => 1m,
      _ => 0m,
    });
    var pricePerAccessories = pricePerDay * accessoriesCharge;

    return pricePerAccessories;
  }

  private static decimal GetPriceMaintained(decimal pricePerDay, Amount maintained)
  {
    var pricePerMaintained = pricePerDay * maintained.Value;
    return pricePerMaintained;
  }
}
