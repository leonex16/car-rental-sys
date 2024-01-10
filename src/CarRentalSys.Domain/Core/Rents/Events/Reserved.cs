using CarRentalSys.Domain.Abstractions;

namespace CarRentalSys.Domain.Core.Rents.Events;

public record Reserved(Guid Identifier) : IDomainEvent;
