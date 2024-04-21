using System.ComponentModel.DataAnnotations;

namespace ConsoleAppUserBusiness.DTOs;

/// <summary>
/// Represents a DTO (Data Transfer Object) for a business, capable of handling notifications.
/// </summary>
public class BusinessDTO : ValidableDTO
{
    /// <summary>
    /// Gets the unique identifier of the business owner.
    /// </summary>
    [Required(ErrorMessage = "The business owner ID is required.")]
    [Range(1, int.MaxValue)]
    public required int UserId { get; set; }

    /// <summary>
    /// Gets or sets the name of the business.
    /// </summary>
    [Required(ErrorMessage = "The business name is required.")]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the CIF (Tax Identification Number) of the business.
    /// </summary>
    [Required(ErrorMessage = "The CIF is required.")]
    [RegularExpression(@"^\d{8}[A-Za-z]$", ErrorMessage = "The CIF must have 8 digits followed by a letter.")]
    public required string CIF { get; set; }

    /// <summary>
    /// Gets or sets the address of the business.
    /// </summary>
    [Required(ErrorMessage = "The business address is required.")]
    public required string Address { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the business.
    /// </summary>
    [Required(ErrorMessage = "The business phone number is required.")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "The phone number must have 9 digits.")]
    public required string Phone { get; set; }
}
