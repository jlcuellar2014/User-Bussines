using Microsoft.EntityFrameworkCore;
using BusinessManagement.Domain.Repositories;

namespace BusinessManagement.Infrastructure.Data.DbContexts;

/// <summary>
/// Represents the database context interface for managing business-related entities.
/// </summary>
public interface IBusinessDbContext : IUnitOfWork
{
    /// <summary>
    /// Gets or sets the <see cref="DbSet{TEntity}"/> for the <see cref="Business"/> entity.
    /// </summary>
    DbSet<Business> Business { get; set; }
}