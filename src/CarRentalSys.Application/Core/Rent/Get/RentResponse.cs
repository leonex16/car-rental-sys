namespace CarRentalSys.Application.Core.Rent.Get;

public abstract record RentResponse
{
  public Guid Identifier { get; init; }
  public Guid UserId { get; init; }
  public Guid VehicleId { get; init; }
  public int Status { get; init; }
  public decimal UsePrice { get; init; }
  public required string UseCurrency { get; init; }
  public decimal MaintainedPrice { get; init; }
  public required string MaintainedCurrency { get; init; }
  public decimal AccessoriesPrice { get; init; }
  public required string AccessoriesCurrency { get; init; }
  public decimal Total { get; init; }
  public required string TotalCurrency { get; init; }
  public DateOnly StartDate { get; init; }
  public DateOnly EndDate { get; init; }
  public DateTime CreatedAt { get; init; }
}
