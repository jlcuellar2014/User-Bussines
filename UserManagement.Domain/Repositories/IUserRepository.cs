using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories;

public interface IUserRepository
{
    IUnitOfWork UnitOfWork { get; }
    public Task AddAsync(User user);
    public Task<User?> FindByDniAsync(string dni);
}
