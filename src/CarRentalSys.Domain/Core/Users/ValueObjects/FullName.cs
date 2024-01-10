namespace CarRentalSys.Domain.Core.Users.ValueObjects;

public record FullName(
  string Name,
  string LastName
)
{
  public override string ToString() => $"{Name} {LastName}";
};
