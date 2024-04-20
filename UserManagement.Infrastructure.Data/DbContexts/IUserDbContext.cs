using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;

namespace UserManagement.Infrastructure.Data.DbContexts;
public interface IUserDbContext : IUnitOfWork
{
    DbSet<User> Users { get; set; }
}