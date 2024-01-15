using CarRentalSys.Application.Abstractions.Data;
using CarRentalSys.Application.Abstractions.Email;
using CarRentalSys.Domain.Abstractions;
using CarRentalSys.Domain.Core.Rents;
using CarRentalSys.Domain.Core.Users;
using CarRentalSys.Domain.Core.Vehicles;
using CarRentalSys.Infrastructure.Abstractions.Data;
using CarRentalSys.Infrastructure.Abstractions.Email;
using CarRentalSys.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentalSys.Infrastructure;

public static class DependencyInjection
{
  public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
  {
    var connectionString = configuration.GetConnectionString("Database") ??
                           throw new ArgumentNullException(nameof(configuration));

    services.AddTransient<IEmailService, EmailService>();

    services.AddDbContext<ApplicationDbContext>(options =>
    {
      options.UseSqlite(connectionString).UseSnakeCaseNamingConvention();
    });

    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IVehicleRepository, VehicleRepository>();
    services.AddScoped<IRentRepository, RentRepository>();
    services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

    services.AddSingleton<ISqlConnectionFactory>(_ => new SqlConnection(connectionString));

    SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
    return services;
  }
}
