using BusinessManagement.Application.Services;

namespace BusinessManagement.API.Extensions;

/// <summary>
/// Extension methods for adding services to the service collection.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Adds business-related services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the business-related services will be added.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBusinessService, BusinessService>();

        return services;
    }
}