using Microsoft.AspNetCore.Mvc;
using NotificationService.Data;
using NotificationService.Services.Implementations;

namespace NotificationService.Controller;

public class NotificationController : ControllerBase
{
    private readonly NotificationContext _notificationContext;
    private readonly TelegramNotificationStrategy _telegramStrategy;
    private readonly WhatsAppNotificationStrategy _whatsAppStrategy;


    public NotificationController(NotificationContext notificationContext,
        TelegramNotificationStrategy telegramStrategy, WhatsAppNotificationStrategy whatsAppStrategy)
    {
        _notificationContext = notificationContext;
        _telegramStrategy = telegramStrategy;
        _whatsAppStrategy = whatsAppStrategy;
    }

    [HttpPost("Telegram")]
    public async Task<IActionResult> SendTelegramNotification([FromBody] string message)
    {
        _notificationContext.SetStrategy(_telegramStrategy);
        await _notificationContext.SendNotificationAsync("Pro", message);
        return Ok("Telegram message sent!");
    }

    [HttpPost("Whatsapp")]
    public async Task<IActionResult> SendWhatsAppNotification([FromBody] string message)
    {
        _notificationContext.SetStrategy(_whatsAppStrategy);
        await _notificationContext.SendNotificationAsync("Monika", message);
        return Ok("WhatsApp message sent!");
    }
}