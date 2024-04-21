using BusinessManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessManagement.Infrastructure.Data.Configurations.Entities;

/// <summary>
/// Provides entity type configuration for the <see cref="Business"/> entity.
/// </summary>
public class BusinessConfigurations : IEntityTypeConfiguration<Business>
{
    /// <summary>
    /// Configures the entity type for the <see cref="Business"/> entity.
    /// </summary>
    /// <param name="businessBuilder">The builder for configuring the <see cref="Business"/> entity.</param>
    public void Configure(EntityTypeBuilder<Business> businessBuilder)
    {
        businessBuilder.Property(e => e.Name).IsRequired();
        businessBuilder.Property(e => e.UserId).IsRequired();
        businessBuilder.Property(e => e.CIF).IsRequired();
        businessBuilder.Property(e => e.Address).IsRequired();
        businessBuilder.Property(e => e.Phone).IsRequired();
    }
}