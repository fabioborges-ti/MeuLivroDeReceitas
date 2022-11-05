using FluentMigrator.Runner;
using MeuLivroDeReceitas.Domain.Repositories;
using MeuLivroDeReceitas.Infrastructure.Context;
using MeuLivroDeReceitas.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeuLivroDeReceitas.Infrastructure;

public static class Bootstrapper
{
    public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        AddFluentMigrator(services, configuration);
        AddContext(services, configuration);
        AddDependencyInjection(services);
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

    private static void AddContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("db")));
    }

    private static void AddDependencyInjection(IServiceCollection services)
    {
        services
            .AddScoped<IUow, Uow>()
            .AddScoped<IUserWriteOnlyRepository, UserRepository>()
            .AddScoped<IUserReadOnlyRepository, UserRepository>();
    }
}
