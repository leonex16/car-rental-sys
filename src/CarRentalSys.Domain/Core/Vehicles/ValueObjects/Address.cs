namespace CarRentalSys.Domain.Core.Vehicles.ValueObjects;

public record Address(
  string Department,
  string Province,
  string City,
  string Country
);
