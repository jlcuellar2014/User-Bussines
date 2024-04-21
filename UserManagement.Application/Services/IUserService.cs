using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services;
/// <summary>
/// Represents a service for managing users.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Creates a new user asynchronously based on the provided user data.
    /// </summary>
    /// <param name="userDTO">The DTO containing the user information.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the DTO of the newly created user if successful,
    /// or the input DTO with error notifications if the operation fails.
    /// </returns>
    Task<UserDTO> CreateUserAsync(UserDTO userDTO);
}