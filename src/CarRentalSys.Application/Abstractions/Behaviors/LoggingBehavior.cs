using CarRentalSys.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CarRentalSys.Application.Abstractions.Behaviors;

public sealed class LoggingBehavior<TRequest, TResponse>(ILogger<TRequest> logger)
  : IPipelineBehavior<TRequest, TResponse>
  where TRequest : ICommand, ICommand<TResponse>
{
  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    var name = request.GetType().Name;
    try
    {
      logger.LogInformation($"Executing {name}");
      return await next();
    }
    catch (Exception e)
    {
      logger.LogError($"{name} has been errors");
      logger.LogError(e.Message);
      throw;
    }

  }
}
