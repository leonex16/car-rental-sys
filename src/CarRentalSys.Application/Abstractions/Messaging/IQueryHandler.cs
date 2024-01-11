using CarRentalSys.Domain.Abstractions;
using MediatR;

namespace CarRentalSys.Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse>
  : IRequestHandler<TQuery, Result<TResponse>>
  where TQuery : IQuery<TResponse>;
