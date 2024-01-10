using CarRentalSys.Domain.Abstractions;
using CarRentalSys.Domain.Core.Vehicles.ValueObjects;
using CarRentalSys.Domain.Shared.Enums;
using CarRentalSys.Domain.Shared.ValueObjects;

namespace CarRentalSys.Domain.Core.Vehicles;

public sealed class Vehicle(
  string model,
  string vin,
  Address address,
  Amount pricePerDay,
  Amount maintained,
  DateTime latestRentDate,
  List<Accessory> accessories)
  : Entity
{
  public string Model { get; private set; } = model;
  public string Vin { get; private set; } = vin;
  public Address Address { get; private set; } = address;
  public Amount PricePerDay { get; private set; } = pricePerDay;
  public Amount Maintained { get; private set; } = maintained;
  public DateTime LatestRentDate { get; private set; } = latestRentDate;
  public List<Accessory> Accessories { get; private set; } = accessories;
}
