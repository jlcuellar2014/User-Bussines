namespace UserManagement.Domain.Repositories;

/// <summary>
/// Represents a unit of work for managing data operations within a repository.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Asynchronously saves changes made in the unit of work to the underlying data store.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the number of state entries written to the underlying data store.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
}