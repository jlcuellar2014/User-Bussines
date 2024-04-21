using Microsoft.Extensions.Logging;
using Moq;
using UserManagement.Application.DTOs;
using UserManagement.Application.DTOs.Notifications;
using UserManagement.Application.Services;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using UserManagement.Infrastructure.Data.DbContexts;

namespace UserManagement.Application.UnitTests.Services;

[TestFixture]
public class UserServiceUnitTests
{
    [Test]
    public async Task WhenCreateUserWithValidDataAndReturnTheCreatedUserDtoAsync()
    {
        // Arrange
        var userUoWMock = new Mock<IUnitOfWork>();
        var userRepoMock = new Mock<IUserRepository>();
        var loggerMock = new Mock<ILogger<UserService>>();

        userUoWMock.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        userRepoMock.SetupGet(r => r.UnitOfWork).Returns(userUoWMock.Object);

        var newUser = new UserDTO
        {
            Name = "Name",
            LastName = "Last Name",
            Email = "name@company.domain",
            DNI = "70268873Y"
        };

        var userService = new UserService(userRepoMock.Object, loggerMock.Object);

        // Act
        var createdUser = await userService.CreateUserAsync(newUser);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(createdUser, Is.Not.Null);
            Assert.That(createdUser.IsValid, Is.True);
        });
    }

    [Test]
    public async Task WhenCreateUserWithInUseDniAndReturnAnUserDtoWithNotificationsAsync()
    {
        // Arrange
        var newUserToCreate = new UserDTO
        {
            Name = "Name",
            LastName = "Last Name",
            Email = "name@company.domain",
            DNI = "70268873Y"
        };

        var userCreatedInDb = new User
        {
            Name = "User In Db - Name",
            LastName = "User In Db - Last Name",
            Email = "user_in_db@company.domain",
            DNI = newUserToCreate.DNI
        };

        var userRepoMock = new Mock<IUserRepository>();
        var loggerMock = new Mock<ILogger<UserService>>();

        userRepoMock.Setup(r => r.FindByDniAsync(It.IsAny<string>())).ReturnsAsync(userCreatedInDb);

        var userService = new UserService(userRepoMock.Object, loggerMock.Object);

        // Act
        var createdUser = await userService.CreateUserAsync(newUserToCreate);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(createdUser, Is.Not.Null);
            Assert.That(createdUser.IsValid, Is.False);
            Assert.That(createdUser.Notifications.Any(n => n.NotificationType.Equals(NotificationType.UserExistWithSameDni)), Is.True);
        });
    }
}
