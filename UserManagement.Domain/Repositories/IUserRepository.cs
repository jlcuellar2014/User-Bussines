using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Repositories;

/// <summary>
/// Represents a repository for managing user data.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Gets the unit of work associated with the repository.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

    /// <summary>
    /// Adds a new user asynchronously.
    /// </summary>
    /// <param name="user">The user to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(User user);

    /// <summary>
    /// Finds a user by their DNI (Document National Identity) asynchronously.
    /// </summary>
    /// <param name="dni">The DNI of the user to find.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the found user, if any.</returns>
    Task<User?> FindByDniAsync(string dni);
}
