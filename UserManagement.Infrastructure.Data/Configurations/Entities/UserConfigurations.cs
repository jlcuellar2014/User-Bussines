using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Data.Configurations.Entities;
public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> userBuilder)
    {
        userBuilder.Property(e => e.Name).IsRequired();
        userBuilder.Property(e => e.LastName).IsRequired();
        userBuilder.Property(e => e.Email).IsRequired();
        userBuilder.Property(e => e.DNI).IsRequired();

        userBuilder.HasIndex(e => e.DNI).IsUnique();
    }
}
