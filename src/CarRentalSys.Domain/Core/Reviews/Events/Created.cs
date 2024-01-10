using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Reviews.Events;

public record Created(Guid Identifier) : IDomainEvent;
