using BusinessBusinessConsoleApp.Services;
using ConsoleAppUserBusiness.DTOs;
using ConsoleAppUserBusiness.Services;

namespace ConsoleAppUserBusiness;
public class Program
{
    // This URLs neet to be in a config file
    private static readonly string userApiUrl = "https://localhost:7046/";
    private static readonly string businessApiUrl = "https://localhost:32772/";

    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to the user-business registry!\n\n");

        var userId = RegisterUser();

        if (userId is null)
        {
            Console.WriteLine("An error occurred while registering the user data.");

            Console.ReadLine();
            Environment.Exit(0);
        }

        var wasRegister = RegisterBusiness(userId.Value);

        if (!wasRegister)
        {
            Console.WriteLine("An error occurred while registering the business data.");

            Console.ReadLine();
            Environment.Exit(0);
        }

        Console.Clear();

        Console.WriteLine("The user and the company were successfully registered.");
        Console.ReadLine();
    }

    private static int? RegisterUser()
    {
        Console.WriteLine("\nIntroduce the user info:");

        UserDTO userData;

        while (true)
        {
            Console.WriteLine("- Name:");
            var name = Console.ReadLine();

            Console.WriteLine("- Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("- Email:");
            var email = Console.ReadLine();

            Console.WriteLine("- DNI:");
            var dni = Console.ReadLine();

            userData = new UserDTO
            {
                Name = name!,
                LastName = lastName!,
                DNI = dni!,
                Email = email!,
            };

            if (userData.IsValid())
            {
                break;
            }
        }

        var httpClient = new HttpClient() { BaseAddress = new Uri(userApiUrl) };

        var service = new UserService(httpClient);

        return service.RegisterUserAsync(userData).Result;
    }

    private static bool RegisterBusiness(int userId)
    {
        Console.WriteLine("\nIntroduce the business info:");

        BusinessDTO businessData;

        while (true)
        {
            Console.WriteLine("- Name:");
            var name = Console.ReadLine();

            Console.WriteLine("- Phone:");
            var phone = Console.ReadLine();

            Console.WriteLine("- Address:");
            var address = Console.ReadLine();

            Console.WriteLine("- CIF:");
            var cif = Console.ReadLine();

            businessData = new BusinessDTO
            {
                UserId = userId,
                Name = name!,
                Phone = phone!,
                Address = address!,
                CIF = cif!
            };

            if (businessData.IsValid())
            {
                break;
            }
        }

        var httpClient = new HttpClient() { BaseAddress = new Uri(businessApiUrl) };

        var service = new BusinessService(httpClient);

        return service.RegisterBusinessAsync(businessData).Result;
    }
}