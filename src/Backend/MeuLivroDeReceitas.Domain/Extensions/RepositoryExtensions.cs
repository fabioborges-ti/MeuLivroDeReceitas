using Microsoft.Extensions.Configuration;

namespace MeuLivroDeReceitas.Domain.Extensions;

public static class RepositoryExtensions
{
    public static string GetConnection(this IConfiguration configuration)
    {
        return configuration.GetConnectionString("db");
    }

    public static string GetDatabase(this IConfiguration configuration)
    {
        return configuration.GetSection("Database:Name").Value;
    }
}
