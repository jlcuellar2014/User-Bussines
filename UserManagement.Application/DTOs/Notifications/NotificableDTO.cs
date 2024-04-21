namespace UserManagement.Application.DTOs.Notifications;

/// <summary>
/// Represents a base class for DTOs that can be notified of errors or warnings.
/// </summary>
public abstract class NotificableDTO
{
    // Collection of predefined notifications.
    private static readonly ICollection<Notification> notifications = new List<Notification>()
    {
        new Notification(NotificationType.UserExistWithSameDni, "There is already a user with the same DNI."),
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
}