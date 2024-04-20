using UserManagement.Application.DTOs;
using UserManagement.Domain.Repositories;
using Mapster;
using UserManagement.Domain.Entities;

namespace UserManagement.Application.Services;
public class UserService(IUserRepository userRepository) : IUserService
{
    public async Task CreateAsync(UserDTO userDTO)
    {
        var newUser = userDTO.Adapt<User>();

        await userRepository.AddAsync(newUser);
        await userRepository.UnitOfWork.SaveChangesAsync();
    }
}
