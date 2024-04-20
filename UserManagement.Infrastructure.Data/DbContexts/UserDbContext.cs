using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Data.DbContexts;
public class UserDbContext : DbContext, IUserDbContext
{
    public DbSet<User> Users { get; set; }
}
