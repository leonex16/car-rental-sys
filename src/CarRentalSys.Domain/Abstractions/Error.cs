namespace CarRentalSys.Domain.Abstractions;

public record Error(
  string Code,
  string Name)
{
  public static Error None = new Error(string.Empty, string.Empty);
  public static Error NullValue = new Error("Error.Null", "Cannot be null");
};