using CarRentalSys.Domain.Core.Rents.ValueObjects;
using CarRentalSys.Domain.Core.Vehicles;

namespace CarRentalSys.Domain.Core.Rents;

public interface IRentRepository
{
  Task<Rent?> GetByIdAsync(Guid identifier, CancellationToken cancellationToken = default);
  Task<bool> IsOverlappingAsync(Vehicle vehicle, DateRange Range, CancellationToken cancellationToken = default);
  void Add(Rent rent);
}
