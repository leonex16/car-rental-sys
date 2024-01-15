using CarRentalSys.Domain.Core.Vehicles;

namespace CarRentalSys.Infrastructure.Repositories;

public sealed class VehicleRepository(ApplicationDbContext dbContext) : Repository<Vehicle>(dbContext), IVehicleRepository;
