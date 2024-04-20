using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using CommunityToolkit.Diagnostics;

namespace UserManagement.Domain.Entities;

public class User
{
    private string name;
    private string lastName;
    private string email;
    private string dni;

    [SetsRequiredMembers]
    public User(string name, string lastName, string email, string dni)
    {
        this.Name = name;
        this.LastName = lastName;
        this.Email = email;
        this.DNI = dni;
    }

    public int Id { get; private set; }

    public required string Name
    {
        get => name;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);

            name = value;
        }
    }

    public required string LastName
    {
        get => lastName;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);

            lastName = value;
        }
    }

    public required string Email
    {
        get => email;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            Guard.IsTrue(IsValidEmail(value));

            email = value;
        }
    }

    public required string DNI
    {
        get => dni;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            Guard.IsTrue(IsValidDni(value));

            dni = value;
        }
    }

    private bool IsValidEmail(string email)
        => Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

    private bool IsValidDni(string dni)
        => Regex.IsMatch(dni, @"^\d{8}[A-Za-z]$");
}
