using BusinessManagement.Domain.Repositories;
using BusinessManagement.Infrastructure.Data.Repositories;

namespace BusinessManagement.API.Extensions;

/// <summary>
/// Extension methods for adding repositories to the service collection.
/// </summary>
public static class RepositoryExtensions
{
    /// <summary>
    /// Adds business repositories to the service collection.
    /// </summary>
    /// <param name="repositories">The service collection to which the business repositories will be added.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection repositories)
    {
        repositories.AddScoped<IBusinessRepository, BusinessRepository>();

        return repositories;
    }
}