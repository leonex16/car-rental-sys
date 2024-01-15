
using CarRentalSys.Domain.Core.Rents;
using CarRentalSys.Domain.Core.Rents.Enums;
using CarRentalSys.Domain.Core.Rents.ValueObjects;
using CarRentalSys.Domain.Core.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace CarRentalSys.Infrastructure.Repositories;

public sealed class RentRepository(ApplicationDbContext dbContext) : Repository<Rent>(dbContext), IRentRepository
{
  private static readonly Status[] RentStates =
  [
    Status.Reserved, Status.Confirmed, Status.Completed
  ];

  public async Task<bool> IsOverlappingAsync(Vehicle vehicle, DateRange range, CancellationToken cancellationToken = default)
  {
    return await dbContext.Set<Rent>()
      .AnyAsync(
        rent =>
          rent.VehicleId == vehicle.Identifier &&
          rent.Range.From <= range.To &&
          rent.Range.To >= range.From &&
          RentStates.Contains(rent.Status),
        cancellationToken);
  }
}
