using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using CommunityToolkit.Diagnostics;

namespace UserManagement.Domain.Entities;

/// <summary>
/// Represents a user entity with properties such as name, last name, email, and DNI (Documento Nacional de Identidad).
/// </summary>
public class User
{
    private string name;
    private string lastName;
    private string email;
    private string dni;

    /// <summary>
    /// Gets the unique identifier of the user.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    public string Name
    {
        get => name;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            name = value;
        }
    }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName
    {
        get => lastName;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            lastName = value;
        }
    }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Email
    {
        get => email;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            Guard.IsTrue(IsValidEmail(value));
            email = value;
        }
    }

    /// <summary>
    /// Gets or sets the DNI (Documento Nacional de Identidad) of the user.
    /// </summary>
    public string DNI
    {
        get => dni;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            Guard.IsTrue(IsValidDni(value));

            dni = value.ToUpper();
        }
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current user instance.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (Id.Equals(((User)obj!).Id)) return true;

        if (DNI.Equals(((User)obj!).DNI, StringComparison.InvariantCulture)) return true;

        return false;
    }

    private bool IsValidEmail(string email)
        => Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

    private bool IsValidDni(string dni)
        => Regex.IsMatch(dni, @"^\d{8}[A-Za-z]$");
}

