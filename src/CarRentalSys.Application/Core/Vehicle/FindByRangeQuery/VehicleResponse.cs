namespace CarRentalSys.Application.Core.Vehicle.FindByRangeQuery;

public abstract record VehicleResponse
{
  public Guid Identifier;
  public required string Model;
  public required string Vin;
  public decimal Price;
  public required string PriceCurrency;
  public required AddressResponse AddressResponse;
}
