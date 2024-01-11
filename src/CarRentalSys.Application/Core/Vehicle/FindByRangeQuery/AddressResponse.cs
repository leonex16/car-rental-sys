namespace CarRentalSys.Application.Core.Vehicle.FindByRangeQuery;

public abstract record AddressResponse
{
  public required string Country;
  public required string Department;
  public required string Province;
  public required string City;
  public required string Street;
}
