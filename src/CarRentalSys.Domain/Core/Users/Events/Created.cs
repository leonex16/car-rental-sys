using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Users.Events;

public record Created(Guid Identifier) : IDomainEvent;
