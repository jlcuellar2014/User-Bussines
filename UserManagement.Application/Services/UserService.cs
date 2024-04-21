using UserManagement.Application.DTOs;
using UserManagement.Domain.Repositories;
using Mapster;
using UserManagement.Domain.Entities;
using UserManagement.Application.DTOs.Notifications;
using Microsoft.Extensions.Logging;

namespace UserManagement.Application.Services;
public class UserService(
        IUserRepository userRepository,
        ILogger<UserService> logger)
    : IUserService
{
    public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
    {
        var newUser = userDTO.Adapt<User>();

        // Validate is not double
        var matchedUser = await userRepository.FindByDniAsync(newUser.DNI);


        if (matchedUser is not null)
        {
            userDTO.ReportError(NotificationType.UserExistWithSameDni);

            logger.LogWarning("There is already a user with the same DNI.");
        }

        // If you want to check more pre-conditions before to add the new user
        // you can make it, here.

        if (!userDTO.IsValid)
        {
            return userDTO;
        }

        await userRepository.AddAsync(newUser);
        await userRepository.UnitOfWork.SaveChangesAsync();

        logger.LogInformation("The user was created successfully.");

        return newUser.Adapt<UserDTO>();
    }
}
