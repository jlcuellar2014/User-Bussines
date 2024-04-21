using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Data.Configurations.Entities;

namespace UserManagement.Infrastructure.Data.DbContexts;

/// <summary>
/// Represents the database context for managing user-related entities.
/// </summary>
public class UserDbContext : DbContext, IUserDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserDbContext"/> class with the specified options.
    /// </summary>
    /// <param name="options">The options for configuring the context.</param>
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    /// <inheritdoc/>>
    public DbSet<User> Users { get; set; }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfigurations());

        base.OnModelCreating(modelBuilder);
    }
}