namespace UserBusinessConsoleApp.DTOs;

/// <summary>
/// Represents a DTO (Data Transfer Object) for a user, capable of handling notifications.
/// </summary>
public class UserDTO
{
    /// <summary>
    /// Gets or sets the ID of the user.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the user.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Gets or sets the DNI (National Identity Document) of the user.
    /// </summary>
    public required string DNI { get; set; }
}
