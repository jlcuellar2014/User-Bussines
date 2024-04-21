using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.API.Extensions;

/// <summary>
/// Extension methods for adding repositories to the service collection.
/// </summary>
public static class RepositoryExtensions
{
    /// <summary>
    /// Adds user repositories to the service collection.
    /// </summary>
    /// <param name="repositories">The service collection to which the user repositories will be added.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection repositories)
    {
        repositories.AddScoped<IUserRepository, UserRepository>();

        return repositories;
    }
}