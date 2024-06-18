namespace NotificationService.Services.Interfaces;

public interface INotificationStrategy
{
    Task SendMessageAsync(string recipient, string message);
}