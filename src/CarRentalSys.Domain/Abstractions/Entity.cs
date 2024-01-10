namespace CarRentalSys.Domain.Abstractions;

public abstract class Entity(Guid? identifier = null)
{
  private readonly List<IDomainEvent> _domainEvents = [];

  public Guid Identifier { get; init; } = identifier ?? Guid.NewGuid();

  public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents;

  public void ClearDomainEvents() => _domainEvents.Clear();

  protected void AddDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
}