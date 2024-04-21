using UserManagement.BaseIntegrationTests;

namespace UserManagement.API.IntegrationTests.Controllers;

[TestFixture]
public class UsersControllerIntegrationTests : UserBaseIntegrationTest
{
    [Test]
    public async Task WhenCreateUserWhidValidDataAndReturnCreateMessage()
    {
        // Arrange

        // Act

        // Assert
    }

    [Test]
    public async Task WhenCreateUserWithInUseDniAndReturnConflictMessage()
    {
        // Arrange

        // Act

        // Assert
    }

    [Test]
    public async Task WhenCreateUserWithInvalidDataAndReturnConflictMessage()
    {
        // Arrange

        // Act

        // Assert
    }
}
