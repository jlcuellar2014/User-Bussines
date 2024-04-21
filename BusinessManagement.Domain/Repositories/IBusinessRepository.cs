namespace BusinessManagement.Domain.Repositories;

/// <summary>
/// Represents a repository for managing business data.
/// </summary>
public interface IBusinessRepository
{
    /// <summary>
    /// Gets the unit of work associated with the repository.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

    /// <summary>
    /// Adds a new business asynchronously.
    /// </summary>
    /// <param name="business">The business to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(Business business);
}
