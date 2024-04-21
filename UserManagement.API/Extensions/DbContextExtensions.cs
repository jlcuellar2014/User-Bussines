using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using UserManagement.Infrastructure.Data.DbContexts;

namespace UserManagement.API.Extensions;

/// <summary>
/// Extension methods for configuring and adding user database context to the service collection.
/// </summary>
public static class DbContextExtensions
{
    /// <summary>
    /// Adds the user database context to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the user database context will be added.</param>
    /// <param name="connectionString">The connection string to the user database.</param>
    /// <returns>The modified service collection.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the connection string is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the connection string is empty or consists only of white space.</exception>
    public static IServiceCollection AddUserDbContext(this IServiceCollection services, string? connectionString)
    {
        Guard.IsNotNull(connectionString);
        Guard.IsNotEmpty(connectionString);
        Guard.IsNotWhiteSpace(connectionString);

        services.AddDbContext<IUserDbContext, UserDbContext>(
            options =>
            {
                options.UseSqlite(
                    connectionString,
                    sqliteOptions => sqliteOptions.MigrationsAssembly("UserManagement.Infrastructure.Data"));
            }, ServiceLifetime.Scoped);

        return services;
    }
}
