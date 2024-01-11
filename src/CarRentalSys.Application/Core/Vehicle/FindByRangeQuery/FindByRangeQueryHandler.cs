using CarRentalSys.Application.Abstractions.Data;
using CarRentalSys.Application.Abstractions.Messaging;
using CarRentalSys.Domain.Abstractions;
using CarRentalSys.Domain.Core.Rents.Enums;
using Dapper;

namespace CarRentalSys.Application.Core.Vehicle.FindByRangeQuery;

internal sealed class FindByRangeQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
  : IQueryHandler<FindByRangeQuery, IReadOnlyList<VehicleResponse>>
{
  private readonly int[] ActiveRentStates =
  [
    (int)Status.Reserved,
    (int)Status.Confirmed,
    (int)Status.Completed
  ];

  public async Task<Result<IReadOnlyList<VehicleResponse>>> Handle(FindByRangeQuery request,
    CancellationToken cancellationToken)
  {
    if (request.StartDate > request.EndDate) return new List<VehicleResponse>();

    using var connection = sqlConnectionFactory.CreateConnection();

    const string sql = """
          SELECT
             vehicle.id AS Identifier,
             vehicle.modelo AS Model,
             vehicle.vin AS Vin,
             vehicle.precio_monto AS Price,
             vehicle.precio_tipo_moneda AS PriceCurrency,
             vehicle.direccion_pais AS Country,
             vehicle.direccion_departamento AS Department,
             vehicle.direccion_provincia AS Province,
             vehicle.direccion_ciudad AS City,
             vehicle.direccion_calle AS Street
          FROM vehiculos AS vehicle
          WHERE NOT EXISTS
          (
                 SELECT 1
                 FROM alquileres AS rent
                 WHERE
                     rent.vehiculo_id = vehicle.id
                     b.duracion_inicio <= @EndDate AND
                     b.duracion_final  >= @StartDate AND
                     b.status = ANY(@ActiveAlquilerStatuses)
          )
     """;

    var vehicles = await connection.QueryAsync<VehicleResponse, AddressResponse, VehicleResponse>(
      sql,
      (vehicle, address) =>
      {
        vehicle.AddressResponse = address;
        return vehicle;
      },
      new
      {
        request.StartDate,
        request.EndDate,
        ActiveRentStates
      },
      splitOn: "Country");

    return vehicles.ToList();
  }
}
