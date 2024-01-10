using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Rents.Events;

public record Completed(Guid Identifier) : IDomainEvent;
