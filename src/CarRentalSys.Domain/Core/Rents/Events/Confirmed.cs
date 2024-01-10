using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Rents.Events;

public record Confirmed(Guid Identifier) : IDomainEvent;
