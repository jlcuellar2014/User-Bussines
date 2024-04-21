using System.Net.Http.Json;
using ConsoleAppUserBusiness.DTOs;

namespace ConsoleAppUserBusiness.Services;

public class UserService(HttpClient httpClient)
{
    public async Task<int?> RegisterUserAsync(UserDTO userDTO)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/users", userDTO);

            response.EnsureSuccessStatusCode();

            if (response.Headers.Location != null)
            {
                string location = response.Headers.Location.ToString();
                
                string[] segments = location.Split('/');
                string idString = segments[segments.Length - 1];

                if (int.TryParse(idString, out int id))
                {
                    return id;
                }
            }

        }
        catch(Exception e)
        {
            // Not implementation
        }

        return null;
    }
}
