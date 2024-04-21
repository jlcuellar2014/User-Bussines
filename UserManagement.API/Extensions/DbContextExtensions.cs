using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using UserManagement.Infrastructure.Data.DbContexts;

namespace UserManagement.API.Extensions;

public static class DbContextExtensions
{
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
