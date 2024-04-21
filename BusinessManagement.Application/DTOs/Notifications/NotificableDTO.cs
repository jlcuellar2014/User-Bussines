namespace BusinessManagement.Application.DTOs.Notifications;

/// <summary>
/// Represents a base class for DTOs that can be notified of errors or warnings.
/// </summary>
public abstract class NotificableDTO
{
    // Collection of predefined notifications.
    private static readonly ICollection<Notification> notifications = new List<Notification>()
    {
        new Notification(NotificationType.Default, "Generic error."),
    };

    // Collection of notifications associated with this DTO instance.
    public ICollection<Notification> Notifications { get; private set; } = new List<Notification>();

    // Indicates whether this DTO has any notifications.
    public bool IsValid => !Notifications.Any();

    /// <summary>
    /// Reports an error of the specified type to this DTO instance.
    /// </summary>
    /// <param name="notificationType">The type of notification to report.</param>
    public void ReportError(NotificationType notificationType)
    {
        var notification = notifications.First(n => n.NotificationType.Equals(notificationType));
        Notifications.Add(notification);
    }

    /// <summary>
    /// Gets a concatenated string containing notification messages.
    /// </summary>
    /// <returns>A string containing notification messages concatenated together.</returns>
    public string GetNotificationMessages()
        => string.Join(" ", Notifications.Select(n => n.Message));
}