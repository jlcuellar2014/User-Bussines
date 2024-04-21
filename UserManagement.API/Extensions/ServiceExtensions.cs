using UserManagement.Application.Services;

namespace UserManagement.API.Extensions;

/// <summary>
/// Extension methods for adding services to the service collection.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds user-related services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the user-related services will be added.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}