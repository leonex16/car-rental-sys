using CarRentalSys.Domain.Abstractions;
using CarRentalSys.Domain.Core.Users.Events;
using CarRentalSys.Domain.Core.Users.ValueObjects;

namespace CarRentalSys.Domain.Core.Users;

public sealed class User : Entity
{
  public FullName FullName { get; private set; }
  public string Email { get; private set; }

  private User(FullName fullName, string email)
  {
    FullName = fullName;
    Email = email;

    AddDomainEvent(new Created(Identifier));
  }

  public static User Create(FullName fullName, string email)
  {
    return new User(fullName, email);
  }
}
