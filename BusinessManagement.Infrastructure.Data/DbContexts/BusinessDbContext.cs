using BusinessManagement.Domain.Repositories;
using BusinessManagement.Infrastructure.Data.Configurations.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessManagement.Infrastructure.Data.DbContexts;

/// <summary>
/// Represents the database context for managing business-related entities.
/// </summary>
public class BusinessDbContext : DbContext, IBusinessDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BusinessDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options for configuring the context.</param>
    public BusinessDbContext(DbContextOptions<BusinessDbContext> options) : base(options)
    {
    }

    /// <inheritdoc/>>
    public DbSet<Business> Businesss { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BusinessConfigurations());

        base.OnModelCreating(modelBuilder);
    }
}