using System.Net;
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

            if (response.StatusCode.Equals(HttpStatusCode.Created))
            {
                if (response.Headers.Location == null)
                {
                    return null;
                }

                string location = response.Headers.Location.ToString();

                string[] segments = location.Split('/');
                string idString = segments[segments.Length - 1];

                if (int.TryParse(idString, out int id))
                {
                    return id;
                }

                return null;
            }

            if (response.StatusCode.Equals(HttpStatusCode.Conflict))
            {
                Console.WriteLine("A user already exists with the same ID.");
            }

            if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                string errorContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"\n{errorContent}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n{e.Message}");
        }

        return null;
    }
}
