using UserManagement.Application.DTOs;

namespace UserManagement.Application.Services;
public interface IUserService
{
    Task CreateAsync(UserDTO userDTO);
}