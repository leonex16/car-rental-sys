using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Rents.Events;

public record Rejected(Guid Identifier) : IDomainEvent;
