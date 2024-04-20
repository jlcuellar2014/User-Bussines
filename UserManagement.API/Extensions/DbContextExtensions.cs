using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using UserManagement.Infrastructure.Data.DbContexts;

namespace UserManagement.API.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection AddUserDbContext(this IServiceCollection services, string? connectionString)
    {
        Guard.IsNull(connectionString);
        Guard.IsEmpty(connectionString!);
        Guard.IsWhiteSpace(connectionString!);

        services.AddDbContext<IUserDbContext, UserDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        return services;
    }
}
