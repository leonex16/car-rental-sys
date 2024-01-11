using CarRentalSys.Domain.Abstractions;
using MediatR;

namespace CarRentalSys.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResponse> : IRequest<Result<TResponse>>;
