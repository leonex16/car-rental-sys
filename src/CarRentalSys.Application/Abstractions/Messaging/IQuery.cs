using CarRentalSys.Domain.Abstractions;
using MediatR;

namespace CarRentalSys.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
