using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Data.DbContexts;

namespace UserManagement.Infrastructure.Data.Repositories;

/// <summary>
/// Provides data access operations for the <see cref="User"/> entity.
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly IUserDbContext userDbContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class with the specified database context.
    /// </summary>
    /// <param name="userDbContext">The database context for user-related entities.</param>
    public UserRepository(IUserDbContext userDbContext)
    {
        this.userDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
    }

    /// <inheritdoc/>
    public IUnitOfWork UnitOfWork => userDbContext;

    /// <inheritdoc/>
    public async Task AddAsync(User user)
    {
        await userDbContext.Users.AddAsync(user);
    }

    /// <inheritdoc/>
    public async Task<User?> FindByDniAsync(string dni)
    {
        return await userDbContext.Users.FirstOrDefaultAsync(u => u.DNI.Equals(dni.ToUpper()));
    }
}