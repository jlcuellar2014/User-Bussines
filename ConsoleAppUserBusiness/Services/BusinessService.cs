using System.Net;
using System.Net.Http.Json;
using ConsoleAppUserBusiness.DTOs;

namespace BusinessBusinessConsoleApp.Services;

public class 
    BusinessService(HttpClient httpClient)
{
    public async Task<bool> RegisterBusinessAsync(BusinessDTO businessDTO)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("api/businesses", businessDTO);

            if (response.StatusCode.Equals(HttpStatusCode.Created))
            {
                return true;
            }

            if (response.StatusCode.Equals(HttpStatusCode.BadRequest))
            {
                string errorContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"\n{errorContent}");
                return false;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n{e.Message}");

            return false;
        }

        return false;
    }
}
