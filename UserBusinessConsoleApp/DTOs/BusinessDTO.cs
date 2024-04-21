namespace UserBusinessConsoleApp.DTOs;

/// <summary>
/// Represents a DTO (Data Transfer Object) for a business, capable of handling notifications.
/// </summary>
public class BusinessDTO
{
    /// <summary>
    /// Gets or sets the ID of the business.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the business owner.
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Gets or sets the name of the business.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the CIF (Tax Identification Number) of the business.
    /// </summary>
    public required string CIF { get; set; }

    /// <summary>
    /// Gets or sets the address of the business.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the business.
    /// </summary>
    public required string Phone { get; set; }
}
