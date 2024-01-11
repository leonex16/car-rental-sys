using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Users;

public static class Errors
{
  public static readonly Error NotFound = new Error(
    "User.NotFound",
    "User not found");
}
