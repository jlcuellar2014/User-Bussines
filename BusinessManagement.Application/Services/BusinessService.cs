using BusinessManagement.Application.DTOs;
using BusinessManagement.Domain.Repositories;
using Mapster;
using Microsoft.Extensions.Logging;

namespace BusinessManagement.Application.Services;

/// <summary>
/// Service for managing business-related operations.
/// </summary>
/// <param name="businessRepository">The repository used for accessing business data.</param>
/// <param name="logger">The logger used for logging in the BusinessService.</param>
public class BusinessService(
        IBusinessRepository businessRepository,
        ILogger<BusinessService> logger)
    : IBusinessService
{
    /// <inheritdoc/>>
    public async Task<BusinessDTO> CreateBusinessAsync(BusinessDTO businessDTO)
    {
        var newBusiness = businessDTO.Adapt<Business>();

        // If you want to check more pre-conditions before to add the new business
        // you can make it, here.

        if (!businessDTO.IsValid)
        {
            return businessDTO;
        }

        await businessRepository.AddAsync(newBusiness);
        await businessRepository.UnitOfWork.SaveChangesAsync();

        logger.LogInformation("The business was created successfully.");

        return newBusiness.Adapt<BusinessDTO>();
    }
}
