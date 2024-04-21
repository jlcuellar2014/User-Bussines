using CommunityToolkit.Diagnostics;
using Microsoft.EntityFrameworkCore;
using UserManagement.Infrastructure.Data.DbContexts;

namespace UserManagement.BaseIntegrationTests;

public class UserBaseIntegrationTest
{
    protected UserManagementWebApplicationFactory UserAPI { get; private set; } = null!;

    [SetUp]
    public async Task SetUp()
    {
        string className = TestContext.CurrentContext.Test.ClassName ?? string.Empty;

        UserAPI = new UserManagementWebApplicationFactory(className);

        Guard.IsNotNull(UserAPI);

        await CreateDbInstanceAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        using (var dbContext = UserAPI.CreateDbContextInstance())
        {
            await DbContextDeleteDatabaseAsync(dbContext);
        }

        UserAPI?.Dispose();
    }

    private async Task CreateDbInstanceAsync()
    {
        using (var dbContext = UserAPI.CreateDbContextInstance())
        {
            await DbContextCreateDatabaseAsync(dbContext);
            await DbContextDeleteDatabaseAsync(dbContext);
            await DbContextMigrateDatabaseAsync(dbContext);
        }
    }

    private async Task DbContextCreateDatabaseAsync(UserDbContext dbContext)
        => await dbContext.Database.EnsureCreatedAsync();

    private async Task DbContextDeleteDatabaseAsync(UserDbContext dbContext)
    {
        bool ensureDeleted = await dbContext.Database.EnsureDeletedAsync();

        Guard.IsTrue(ensureDeleted);
    }

    private async Task DbContextMigrateDatabaseAsync(UserDbContext dbContext)
        => await dbContext.Database.MigrateAsync();
}
