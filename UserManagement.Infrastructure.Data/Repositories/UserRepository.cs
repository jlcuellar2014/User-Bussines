using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Data.DbContexts;

namespace UserManagement.Infrastructure.Data.Repositories;
public class UserRepository(IUserDbContext userDbContext) : IUserRepository
{
    public IUnitOfWork UnitOfWork => userDbContext;

    public async Task AddAsync(User user)
        => await userDbContext.Users.AddAsync(user);

    public async Task<User?> FindByDniAsync(string dni)
        => await userDbContext.Users.FirstOrDefaultAsync(u => u.DNI.Equals(dni.ToUpper()));
}
