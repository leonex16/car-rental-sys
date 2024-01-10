namespace CarRentalSys.Domain.Abstractions;

public interface IUnitOfWork
{
  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}