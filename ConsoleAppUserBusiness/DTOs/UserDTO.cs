using System.ComponentModel.DataAnnotations;

namespace ConsoleAppUserBusiness.DTOs;

/// <summary>
/// Represents a DTO (Data Transfer Object) for a user, capable of handling notifications.
/// </summary>
public class UserDTO : ValidableDTO
{
    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    /// Gets or sets the name of the user.
    /// </summary>
    [Required(ErrorMessage = "The user name is required.")]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    [Required(ErrorMessage = "The user last name is required.")]
    public required string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    [Required(ErrorMessage = "The user email is required.")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "The email must have a valid format.")]
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the DNI (Document National Identity) of the user.
    /// </summary>
    [Required(ErrorMessage = "The user DNI is required.")]
    [RegularExpression(@"^\d{8}[A-Za-z]$", ErrorMessage = "The DNI must have 8 digits followed by a letter.")]
    public required string DNI { get; set; }
}
