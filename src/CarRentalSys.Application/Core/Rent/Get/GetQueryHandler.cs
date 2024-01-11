using System.Diagnostics;
using CarRentalSys.Application.Abstractions.Data;
using CarRentalSys.Application.Abstractions.Messaging;
using CarRentalSys.Domain.Abstractions;
using Dapper;

namespace CarRentalSys.Application.Core.Rent.Get;

internal sealed class GetQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    : IQueryHandler<GetQuery, RentResponse>
{
    public async Task<Result<RentResponse>> Handle(GetQuery request,CancellationToken cancellationToken)
    {
        
        using var connection = sqlConnectionFactory.CreateConnection();

        const string sql = """
           SELECT
            id AS Identifier,
            vehiculo_id AS VehicleId,
            user_id AS UserId,
            status AS Status,
            precio_por_periodo AS UsePrice,
            precio_por_periodo_tipo_moneda AS UseCurrency,
            precio_mantenimiento AS MaintainedPrice,
            precio_mantenimiento_tipo_moneda AS MaintainedCurrency,
            precio_accesorios AS AccessoriesPrice,
            precio_accesorios_tipo_moneda AS AccessoriesCurrency,
            precio_total AS Total,
            precio_total_tipo_moneda AS TotalCurrency,
            duracion_inicio AS StartDate,
            duracion_final AS EndDate,
            fecha_creacion AS CreatedAt
           FROM alquileres WHERE id=@RentId
           """;

        var rent = await connection.QueryFirstOrDefaultAsync<RentResponse>(
            sql,
            new { request.RentId }
        );

        return rent!;
    }
}
