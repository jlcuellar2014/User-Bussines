using Microsoft.EntityFrameworkCore;
using BusinessManagement.Domain.Repositories;
using BusinessManagement.Infrastructure.Data.DbContexts;

namespace BusinessManagement.Infrastructure.Data.Repositories;

/// <summary>
/// Provides data access operations for the <see cref="Business"/> entity.
/// </summary>
/// <param name="businessDbContext">The database context for business-related entities.</param>
public class BusinessRepository(IBusinessDbContext businessDbContext)
    : IBusinessRepository
{
    /// <inheritdoc/>
    public IUnitOfWork UnitOfWork => businessDbContext;

    /// <inheritdoc/>
    public async Task AddAsync(Business business)
    {
        await businessDbContext.Business.AddAsync(business);
    }
}