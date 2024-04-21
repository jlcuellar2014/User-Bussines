using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services;
public interface IUserService
{
    Task<UserDTO> CreateUserAsync(UserDTO userDTO);
}