using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Data.Configurations.Entities;

/// <summary>
/// Provides entity type configuration for the <see cref="User"/> entity.
/// </summary>
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    /// <summary>
    /// Configures the entity type for the <see cref="User"/> entity.
    /// </summary>
    /// <param name="userBuilder">The builder for configuring the <see cref="User"/> entity.</param>
    public void Configure(EntityTypeBuilder<User> userBuilder)
    {
        userBuilder.Property(e => e.Name).IsRequired();
        userBuilder.Property(e => e.LastName).IsRequired();
        userBuilder.Property(e => e.Email).IsRequired();
        userBuilder.Property(e => e.DNI).IsRequired();

        userBuilder.HasIndex(e => e.DNI).IsUnique();
    }
}