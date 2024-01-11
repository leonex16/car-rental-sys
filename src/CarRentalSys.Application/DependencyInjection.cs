using CarRentalSys.Application.Abstractions.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSys.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplication(this IServiceCollection services)
  {
    services.AddMediatR(conf =>
    {
      conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
      conf.AddOpenBehavior(typeof(LoggingBehavior<,>));
    });

    return services;
  }
}


