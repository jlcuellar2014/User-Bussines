using System.Net.Http.Json;
using ConsoleAppUserBusiness.DTOs;

namespace BusinessBusinessConsoleApp.Services;

public class BusinessService(HttpClient httpClient)
{
    public async Task<bool> RegisterBusinessAsync(BusinessDTO businessDTO)
    {
        try
        {
            await httpClient.PostAsJsonAsync("api/business", businessDTO);
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
}
