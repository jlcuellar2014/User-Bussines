using System.Net.Http.Json;
using UserBusinessConsoleApp.DTOs;

namespace BusinessBusinessConsoleApp.Services;

public class BusinessService(HttpClient httpClient)
{
    public async Task<bool> RegitryUregisterAsync(BusinessDTO businessDTO)
    {
        try
        {
            await httpClient.PostAsJsonAsync("api/business", businessDTO);
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }
}
