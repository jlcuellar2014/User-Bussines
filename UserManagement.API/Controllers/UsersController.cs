using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Requests;
using UserManagement.Application.Services;
using Mapster;
using UserManagement.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using UserManagement.Application.DTOs.Notifications;

namespace UserManagement.API.Controllers;

/// <summary>
/// Controller for managing user-related operations.
/// </summary>
/// <param name="userService">The service responsible for user-related operations.</param>
/// <param name="logger">The logger used for logging in the UsersController.</param>
[ApiController]
[Route("api/[controller]")]
public class UsersController(
    IUserService userService,
    ILogger<UsersController> logger)
    : ControllerBase
{
    /// <summary>
    /// Creates a new user asynchronously.
    /// </summary>
    /// <param name="request">The request containing the user information.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the result of the operation, including the created user's location if successful,
    /// or an appropriate error message if the operation fails due to conflicts or invalid input.
    /// </returns>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<Results<Created, Conflict<string>, BadRequest<string>>>
        CreateAsync([FromBody] CreateUserRequest request)
    {
        var createdUser = await userService.CreateUserAsync(request.Adapt<UserDTO>());

        if (createdUser.IsValid)
        {
            return TypedResults.Created($"api/users/{createdUser.Id}");
        }

        logger.LogError("There are errors in the request: {@errorList}.", createdUser.Notifications);

        if (createdUser.Notifications.Any(n => n.NotificationType.Equals(NotificationType.UserExistWithSameDni)))
        {
            return TypedResults.Conflict(createdUser.GetNotificationMessages());
        }

        return TypedResults.BadRequest(createdUser.GetNotificationMessages());
    }
}
