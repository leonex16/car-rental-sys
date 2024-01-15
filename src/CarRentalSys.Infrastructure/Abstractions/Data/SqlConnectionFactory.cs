using System.Data;
using CarRentalSys.Application.Abstractions.Data;
using Microsoft.Data.Sqlite;

namespace CarRentalSys.Infrastructure.Abstractions.Data;

public sealed class SqlConnection(string connectionString) : ISqlConnectionFactory
{
  public IDbConnection CreateConnection()
  {
    var connection = new SqliteConnection(connectionString);
    connection.Open();
    return connection;
  }
}
