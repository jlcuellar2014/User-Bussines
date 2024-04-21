using System.Net.Http.Json;
using UserBusinessConsoleApp.DTOs;

namespace UserBusinessConsoleApp.Services;

public class UserService(HttpClient httpClient)
{
    public async Task<bool> RegisterUserAsync(UserDTO userDTO)
    {
        try
        {
            await httpClient.PostAsJsonAsync("api/users", userDTO);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}
