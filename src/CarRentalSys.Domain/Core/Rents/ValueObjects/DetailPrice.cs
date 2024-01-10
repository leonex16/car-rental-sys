using CarRentalSys.Domain.Shared.ValueObjects;

namespace CarRentalSys.Domain.Core.Rents.ValueObjects;

public record DetailPrice(
  Amount Use,
  Amount Accessories,
  Amount Maintained
)
{
  public Amount Total = new Amount(Use.CurrencyCode, Amount.SumAll(Use, Accessories, Maintained));
};
