using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserManagement.Infrastructure.Data.DbContexts;

namespace UserManagement.BaseIntegrationTests;

public class UserManagementWebApplicationFactory : WebApplicationFactory<Program>
{
    private readonly string connectionString;

    public UserManagementWebApplicationFactory(string instanceTag)
    {
        var dbName = instanceTag.ToLower()
                       .Replace("integrationtests.", string.Empty)
                       .Replace(" ", ".");

        connectionString = $"Data Source={dbName}.db";
    }

    public UserDbContext CreateDbContextInstance()
    {
        var dbContextOptions = new DbContextOptionsBuilder<UserDbContext>()
            .UseSqlite(
                connectionString,
                sqliteOptions => sqliteOptions.MigrationsAssembly("UserManagement.Infrastructure.Data"))
            .Options;

        return new UserDbContext(dbContextOptions);
    }

    /// <inheritdoc/>
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureServices(services =>
        {
            // Remove the currently registered DbContext
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(DbContextOptions<UserDbContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Add your custom DbContext
            services.AddDbContext<UserDbContext>(
                dbContextOptions =>
                dbContextOptions.UseSqlite(
                    connectionString,
                    sqliteOptions => sqliteOptions.MigrationsAssembly("UserManagement.Infrastructure.Data")),
                ServiceLifetime.Scoped);
        });
    }

    /// <inheritdoc/>
    protected override IHost CreateHost(IHostBuilder builder)
    {
        return base.CreateHost(builder);
    }

    /// <inheritdoc/>
    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }
}