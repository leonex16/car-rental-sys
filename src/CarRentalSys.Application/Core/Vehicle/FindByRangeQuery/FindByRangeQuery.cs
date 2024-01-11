using CarRentalSys.Application.Abstractions.Messaging;

namespace CarRentalSys.Application.Core.Vehicle.FindByRangeQuery;

public abstract record FindByRangeQuery(DateOnly StartDate, DateOnly EndDate) : IQuery<IReadOnlyList<VehicleResponse>>;
