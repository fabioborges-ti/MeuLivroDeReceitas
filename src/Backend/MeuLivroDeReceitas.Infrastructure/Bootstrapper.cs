using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeuLivroDeReceitas.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        AddFluentMigrator(services, configuration);
    }

    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("db");

        var database = configuration.GetSection("Database:Name").Value;

        var connectionString = $"{connection};Database={database};";

        services
            .AddFluentMigratorCore()
            .ConfigureRunner(c =>
                c.AddSqlServer().WithGlobalConnectionString(connectionString).ScanIn(Assembly.Load("MeuLivroDeReceitas.Infrastructure")).For.All());
    }
}
