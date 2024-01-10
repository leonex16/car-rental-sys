using MediatR;

namespace CarRentalSys.Domain.Abstractions;

public interface IDomainEvent : INotification
{
  public Guid Identifier { get; init; }
};
