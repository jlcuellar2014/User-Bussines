using Microsoft.AspNetCore.Mvc;
using UserManagement.API.Requests;
using UserManagement.Application.Services;
using Mapster;
using UserManagement.Application.DTOs;

namespace UserManagement.API.Controllers;
[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost]
    public async Task Create([FromBody] CreateUserRequest request)
    {
        await userService.CreateAsync(request.Adapt<UserDTO>());
    }
}
