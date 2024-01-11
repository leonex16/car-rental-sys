using CarRentalSys.Application.Abstractions.Messaging;

namespace CarRentalSys.Application.Core.Rent.Reserve;

public record ReserveCommand(
  Guid vehicleId,
  Guid userId,
  DateTime startDate,
  DateTime endDate
  ) : ICommand<Guid>;
