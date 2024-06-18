using Microsoft.EntityFrameworkCore;
using NotificationService.Entity;
using NotificationService.Services.Interfaces;

namespace NotificationService.Data;

public class NotificationContext : DbContext
{
    private INotificationStrategy _notificationStrategy;

    public void SetStrategy(INotificationStrategy notificationStrategy)
    {
        _notificationStrategy = notificationStrategy;
    }

    public Task SendNotificationAsync(string recipient, string message)
    {
        return _notificationStrategy.SendMessageAsync(recipient, message);
    }
}