using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.Data.DbContexts;
/// <summary>
/// Represents the database context interface for managing user-related entities.
/// </summary>
public interface IUserDbContext : IUnitOfWork
{
    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for the <see cref="User"/> entity.
    /// </summary>
    DbSet<User> Users { get; set; }
}