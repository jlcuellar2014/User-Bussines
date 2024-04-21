using Microsoft.AspNetCore.Mvc;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using BusinessManagement.API.Requests;
using BusinessManagement.Application.Services;
using BusinessManagement.Application.DTOs;

namespace BusinessManagement.API.Controllers;

/// <summary>
/// Controller for managing business-related operations.
/// </summary>
/// <param name="businessService">The service responsible for business-related operations.</param>
/// <param name="logger">The logger used for logging in the BusinesssController.</param>
[ApiController]
[Route("api/[controller]")]
public class BusinessesController(
    IBusinessService businessService,
    ILogger<BusinessesController> logger)
    : ControllerBase
{
    /// <summary>
    /// Creates a new business asynchronously.
    /// </summary>
    /// <param name="request">The request containing the business information.</param>
    /// <returns>
    /// A task representing the asynchronous operation.
    /// The task result contains the result of the operation, including the created business's location if successful,
    /// or an appropriate error message if the operation fails due to conflicts or invalid input.
    /// </returns>
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [HttpPost]
    public async Task<Results<Created, BadRequest<string>>>
        CreateAsync([FromBody] CreateBusinessRequest request)
    {
        var createdBusiness = await businessService.CreateBusinessAsync(request.Adapt<BusinessDTO>());

        if (createdBusiness.IsValid)
        {
            return TypedResults.Created($"api/businesss/{createdBusiness.Id}");
        }

        logger.LogError("There are errors in the request: {@errorList}.", createdBusiness.Notifications);

        return TypedResults.BadRequest(createdBusiness.GetNotificationMessages());
    }
}
