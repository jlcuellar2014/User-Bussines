using System.Runtime.CompilerServices;
using UserManagement.Application.Services;

namespace UserManagement.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this  IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}
