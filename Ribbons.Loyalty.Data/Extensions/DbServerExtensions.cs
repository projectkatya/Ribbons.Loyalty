using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using Ribbons.Data;
using System.Data.Common;

namespace Ribbons.Loyalty.Data.Extensions
{
    public static class DbServerExtensions
    {
        public static string SetDatabase(this DbServer dbServer, string databaseName)
        {
            DbConnectionStringBuilder connectionStringBuilder = dbServer.Provider switch
            {
                DatabaseProvider.MsSql => new SqlConnectionStringBuilder(dbServer.ConnectionString)
                {
                    InitialCatalog = databaseName
                },
                DatabaseProvider.MySql => new MySqlConnectionStringBuilder(dbServer.ConnectionString)
                {
                    Database = databaseName
                },
                DatabaseProvider.Npgsql => new NpgsqlConnectionStringBuilder(dbServer.ConnectionString)
                {
                    Database = databaseName
                },
                DatabaseProvider.Oracle => new OracleConnectionStringBuilder(dbServer.ConnectionString)
                {
                    DataSource = databaseName
                },
                DatabaseProvider.Sqlite => new SqliteConnectionStringBuilder(dbServer.ConnectionString)
                {
                    DataSource = databaseName
                },
                _ => null
            };

            return connectionStringBuilder?.ToString();
        }
    }
}
