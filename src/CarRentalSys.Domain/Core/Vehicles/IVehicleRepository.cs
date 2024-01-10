namespace CarRentalSys.Domain.Core.Vehicles;

public interface IVehicleRepository
{
  Task<Vehicle?> GetByIdAsync(Guid identifier);
}