using CarRentalSys.Application.Abstractions.Messaging;
using CarRentalSys.Domain.Abstractions;
using CarRentalSys.Domain.Core.Rents;
using CarRentalSys.Domain.Core.Rents.ValueObjects;
using CarRentalSys.Domain.Core.Users;
using CarRentalSys.Domain.Core.Vehicles;
using UserErrors = CarRentalSys.Domain.Core.Users.Errors;
using VehicleErrors = CarRentalSys.Domain.Core.Vehicles.Errors;
using RentErrors = CarRentalSys.Domain.Core.Rents.Errors;

namespace CarRentalSys.Application.Core.Rent.Reserve;

internal sealed class ReserveCommandHandler(
  IUserRepository userRepository,
  IVehicleRepository vehicleRepository,
  IRentRepository rentRepository,
  IUnitOfWork unitOfWork)
  : ICommandHandler<ReserveCommand, Guid>
{
  public async Task<Result<Guid>> Handle(ReserveCommand request, CancellationToken cancellationToken)
  {
    var user = await userRepository.GetByIdAsync(request.userId, cancellationToken);
    if (user is null) return Result.Failure<Guid>(UserErrors.NotFound);

    var vehicle = await vehicleRepository.GetByIdAsync(request.userId, cancellationToken);
    if (vehicle is null) return Result.Failure<Guid>(VehicleErrors.NotFound);

    var range = DateRange.Create(request.startDate, request.endDate);
    var isOverlapped = await rentRepository.IsOverlappingAsync(vehicle, range, cancellationToken);

    if (isOverlapped) return Result.Failure<Guid>(RentErrors.Overlap);

    var detailPrice = PriceCalculator.Calculator(vehicle, range);
    var rent = CarRentalSys.Domain.Core.Rents.Rent.Create(
      user.Identifier,
      vehicle.Identifier,
      detailPrice,
      range
    );

    rentRepository.Add(rent);

    await unitOfWork.SaveChangesAsync(cancellationToken);

    return Result.Success(rent.Identifier);
  }
}
