using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using BusinessManagement.Infrastructure.Data.DbContexts;

namespace BusinessManagement.API.Extensions;

/// <summary>
/// Extension methods for configuring and adding business database context to the service collection.
/// </summary>
public static class DbContextExtensions
{
    /// <summary>
    /// Adds the business database context to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the business database context will be added.</param>
    /// <param name="connectionString">The connection string to the business database.</param>
    /// <returns>The modified service collection.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the connection string is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the connection string is empty or consists only of white space.</exception>
    public static IServiceCollection AddBusinessDbContext(this IServiceCollection services, string? connectionString)
    {
        Guard.IsNotNull(connectionString);
        Guard.IsNotEmpty(connectionString);
        Guard.IsNotWhiteSpace(connectionString);

        services.AddDbContext<IBusinessDbContext, BusinessDbContext>(
            options =>
            {
                options.UseSqlite(
                    connectionString,
                    sqliteOptions => sqliteOptions.MigrationsAssembly("BusinessManagement.Infrastructure.Data"));
            }, ServiceLifetime.Scoped);

        return services;
    }
}
