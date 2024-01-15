namespace CarRentalSys.Domain.Shared.ValueObjects;

public record Amount(string CurrencyCode, decimal Value = 0)
{
  public static decimal SumAll(params Amount[] x) => x.Aggregate(0m, (acc, y) => acc+ y.Value);

  public static readonly Amount Usd = new Amount("USD");
  public static readonly Amount Clp = new Amount("CLP");
}
