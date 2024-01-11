using CarRentalSys.Application.Abstractions.Messaging;

namespace CarRentalSys.Application.Core.Rent.Get;


public abstract record GetQuery(Guid RentId) : IQuery<RentResponse>;
