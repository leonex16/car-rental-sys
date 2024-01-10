using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Reviews;

public static class Errors
{
  public static Error NotEligible => new Error(
    "Review.NotEligible",
    "The rent is not complete");
}
