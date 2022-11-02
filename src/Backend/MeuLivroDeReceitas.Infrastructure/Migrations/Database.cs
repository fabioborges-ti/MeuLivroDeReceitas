using Dapper;
using System.Data.SqlClient;

namespace MeuLivroDeReceitas.Infrastructure.Migrations;

public static class Database
{
    public static void CreateDatabase(string connectionString, string database)
    {
        using var connection = new SqlConnection(connectionString);

        connection.Open();

        var parameters = new DynamicParameters();

        parameters.Add("database", database);

        var result = connection.Query("SELECT * FROM master.sys.databases WHERE name = @database", parameters);

        if (!result.Any())
            connection.Execute($"CREATE DATABASE {database}");
    }
}
