using BusinessBusinessConsoleApp.Services;
using ConsoleAppUserBusiness.DTOs;
using ConsoleAppUserBusiness.Services;

namespace ConsoleAppUserBusiness;
public class Program
{
    // This URLs neet to be in a config file
    private static readonly string userApiUrl = "http://localhost:5065";
    private static readonly string businessApiUrl = "http://localhost:5062";

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to the user-business registry!\r\r");

        Console.WriteLine("First introduce you user data:\r");

        var userId = RegisterUser();

        if (userId is null)
        {
            Console.WriteLine("An error occurred while registering the user data.");

            Environment.Exit(1);
        }

        Console.WriteLine("\r\rNow introduce the business data:\r");
    var wasRegister = RegisterBusiness(userId.Value);

        if (!wasRegister)
        {
            Console.WriteLine("An error occurred while registering the business data.");

            Environment.Exit(1);
        }

        Console.WriteLine("The user and companies registered successfully");
    }

    private static int? RegisterUser()
    {
        Console.WriteLine("Name:");
        var name = Console.ReadLine();

        Console.WriteLine("Last Name:");
        var lastName = Console.ReadLine();

        Console.WriteLine("Email:");
        var email = Console.ReadLine();

        Console.WriteLine("DNI:");
        var dni = Console.ReadLine();

        var userData = new UserDTO
        {
            Name = name,
            LastName = lastName,
            DNI = dni,
            Email = email,
        };

        var httpClient = new HttpClient() { BaseAddress = new Uri(userApiUrl) };

        var service = new UserService(httpClient);

        return service.RegisterUserAsync(userData).Result;
    }

    private static bool RegisterBusiness(int userId)
    {
        Console.WriteLine("Name:");
        var name = Console.ReadLine();

        Console.WriteLine("Phone:");
        var phone = Console.ReadLine();

        Console.WriteLine("Address:");
        var address = Console.ReadLine();

        Console.WriteLine("CIF:");
        var cif = Console.ReadLine();

        var businessData = new BusinessDTO
        {
            UserId = userId,
            Name = name,
            Phone = phone,
            Address = address,
            CIF = cif
        };

        var httpClient = new HttpClient() { BaseAddress = new Uri(businessApiUrl) };

        var service = new BusinessService(httpClient);

        return service.RegisterBusinessAsync(businessData).Result;
    }
}