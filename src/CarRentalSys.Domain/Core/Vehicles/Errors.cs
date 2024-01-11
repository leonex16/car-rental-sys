using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Vehicles;

public static class Errors
{
  public static readonly Error NotFound = new Error(
    "Vehicle.NotFound",
    "Vehicle not found");
}
