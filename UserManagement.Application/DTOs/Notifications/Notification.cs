namespace UserManagement.Application.DTOs.Notifications;

/// <summary>
/// Represents a notification with a specific type and message.
/// </summary>
public record Notification(NotificationType NotificationType, string Message);
