using BusinessManagement.Application.DTOs;

namespace BusinessManagement.Application.Services;

/// <summary>
/// Represents a service for managing business.
/// </summary>
public interface IBusinessService
{
    /// <summary>
    /// Creates a new Business asynchronously based on the provided Business data.
    /// </summary>
    /// <param name="businessDTO">The DTO containing the Business information.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the DTO of the newly created Business if successful,
    /// or the input DTO with error notifications if the operation fails.
    /// </returns>
    Task<BusinessDTO> CreateBusinessAsync(BusinessDTO businessDTO);
}