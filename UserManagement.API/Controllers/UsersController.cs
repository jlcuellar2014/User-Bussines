using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Requests;
using UserManagement.Application.Services;
using Mapster;
using UserManagement.Application.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using UserManagement.Application.DTOs.Notifications;

namespace UserManagement.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UsersController(
    IUserService userService,
    ILogger<UsersController> logger)
    : ControllerBase
{
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
