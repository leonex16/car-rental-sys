using CarRentalSys.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSys.Infrastructure.Repositories;

public abstract class Repository<T>(ApplicationDbContext dbContext)
  where T : Entity
{
  protected readonly ApplicationDbContext dbContext = dbContext;

  public async Task<T?> GetByIdAsync(Guid identifier, CancellationToken cancellationToken = default)
  {
    return await dbContext.Set<T>()
      .FirstOrDefaultAsync(entity => entity.Identifier == identifier, cancellationToken: cancellationToken);
  }

  public void Add(T entity)
  {
    dbContext.Add(entity);
  }
}
