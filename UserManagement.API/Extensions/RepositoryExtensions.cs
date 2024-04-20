using UserManagement.Domain.Repositories;

namespace UserManagement.API.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection Repositorys)
    {
        Repositorys.AddScoped<IUserRepository, IUserRepository>();

        return Repositorys;
    }
}
