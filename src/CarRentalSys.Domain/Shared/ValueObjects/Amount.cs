namespace CarRentalSys.Domain.Shared.ValueObjects;

public record Amount
{
  public static decimal SumAll(params Amount[] x) => x.Aggregate(0m, (acc, y) => acc+ y.Value);

  public static readonly Amount Usd = new Amount("USD");
  public static readonly Amount Clp = new Amount("CLP");

  public string CurrencyCode { get; init; }
  public decimal Value { get; set; }

  public Amount(string currencyCode, decimal value = 0)
  {
    CurrencyCode = currencyCode;
    Value = value;
  }
}
