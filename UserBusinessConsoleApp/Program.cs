using UserBusinessConsoleApp.DTOs;

namespace UserBusinessConsoleApp;
public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to the user-business registry!\r\r");

        var userData = new UserDTO();

        Console.WriteLine("Introduce your Name:");
        Console.WriteLine("Introduce your Last Name:");
        Console.WriteLine("Introduce your Email:");
        Console.WriteLine("Introduce your DNI:");
    }
}