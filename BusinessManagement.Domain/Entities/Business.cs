using System.Text.RegularExpressions;
using CommunityToolkit.Diagnostics;

namespace BusinessManagement.Domain.Repositories;
/// <summary>
/// Represents a business entity with properties such as name, address, phone, and CIF (Tax Identification Number).
/// </summary>
public class Business
{
    private string name;
    private string address;
    private string phone;
    private string cif;
    private int userId;

    /// <summary>
    /// Gets the unique identifier of the business.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the unique identifier of the business owner.
    /// </summary>
    public int UserId
    {
        get => userId;
        private set
        {
            Guard.IsNotNull(value);
            Guard.IsNotEqualTo(value, default(int));

            userId = value;
        }
    }

    /// <summary>
    /// Gets or sets the name of the business.
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
    /// Gets or sets the CIF (Tax Identification Number) of the business.
    /// </summary>
    public string CIF
    {
        get => cif;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            Guard.IsTrue(IsValidCif(value));

            cif = value.ToUpper();
        }
    }

    /// <summary>
    /// Gets or sets the address of the business.
    /// </summary>
    public string Address
    {
        get => address;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            address = value;
        }
    }

    /// <summary>
    /// Gets or sets the phone number of the business.
    /// </summary>
    public string Phone
    {
        get => phone;
        set
        {
            Guard.IsNotNullOrWhiteSpace(value);
            Guard.IsTrue(IsValidPhone(value));
            phone = value;
        }
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current business instance.
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (Id.Equals(((Business)obj!).Id)) return true;

        if (cif.Equals(((Business)obj!).cif, StringComparison.InvariantCulture)) return true;

        return false;
    }

    /// <summary>
    /// Validates if the provided phone number is in a valid format.
    /// </summary>
    private bool IsValidPhone(string phone)
        => Regex.IsMatch(phone, @"^\d{9}$");

    /// <summary>
    /// Validates if the provided CIF is in a valid format.
    /// </summary>
    private bool IsValidCif(string cif)
        => Regex.IsMatch(cif, @"^\d{8}[A-Za-z]$");
}