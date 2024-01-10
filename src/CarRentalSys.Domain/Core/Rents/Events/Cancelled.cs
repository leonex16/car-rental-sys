using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Rents.Events;

public record Cancelled(Guid Identifier) : IDomainEvent;
