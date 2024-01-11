using System.Data;

namespace CarRentalSys.Application.Abstractions.Data;

public interface ISqlConnectionFactory
{
  IDbConnection CreateConnection();
}
