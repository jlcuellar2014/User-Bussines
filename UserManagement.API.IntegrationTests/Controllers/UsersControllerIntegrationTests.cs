using System.Net;
using System.Net.Http.Json;
using UserManagement.API.Requests;
using UserManagement.BaseIntegrationTests;
using UserManagement.Domain.Entities;

namespace UserManagement.API.IntegrationTests.Controllers;

[TestFixture]
public class UsersControllerIntegrationTests : UserManagementBaseIntegrationTest
{
    [Test]
    public async Task WhenCreateUserWhidValidDataAndReturnCreateMessage()
    {
        // Arrange
        var request = new CreateUserRequest()
        {
            Name = "Name",
            LastName = "Last Name",
            Email = "name@company.domain",
            DNI = "70268873Y"
        };

        var userClient = UserAPI.CreateClient();

        // Act
        var response = await userClient.PostAsJsonAsync("api/users", request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        });
    }

    [Test]
    public async Task WhenCreateUserWithInUseDniAndReturnConflictMessage()
    {
        // Arrange
        var userInDb = new User()
        {
            Name = "Name",
            LastName = "Last Name",
            Email = "name@company.domain",
            DNI = "70268873Y"
        };

        using (var dbContext = UserAPI.CreateDbContextInstance())
        {
            await dbContext.Users.AddAsync(userInDb);
            await dbContext.SaveChangesAsync();
        }

        var request = new CreateUserRequest()
        {
            Name = "Request Name",
            LastName = "Request Last Name",
            Email = "request@company.domain",
            DNI = userInDb.DNI
        };

        var userClient = UserAPI.CreateClient();

        // Act
        var response = await userClient.PostAsJsonAsync("api/users", request);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(response, Is.Not.Null);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Conflict));
        });
    }
}
