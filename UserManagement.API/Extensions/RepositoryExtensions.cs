using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Data.Repositories;

namespace UserManagement.API.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection Repositorys)
    {
        Repositorys.AddScoped<IUserRepository, UserRepository>();

        return Repositorys;
    }
}
