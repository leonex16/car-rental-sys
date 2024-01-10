using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Rents;

public static class Errors
{
  public static readonly Error NotFound = new Error(
    "Rent.NotFound",
    "No rent found");
  
  public static readonly Error Overlap = new Error(
    "Rent.Overlap",
    "The rent cannot be rented by two or more users on the same date");
  
  public static readonly Error NotReserved = new Error(
    "Rent.NotReserved",
    "The rent isn't reserved");
  
  public static readonly Error NotConfirmed = new Error(
    "Rent.NotConfirmed",
    "The rent isn't confirmed");
  
  public static readonly Error AlreadyStarted = new Error(
    "Rent.AlreadyStarted",
    "The rent is active");
}
