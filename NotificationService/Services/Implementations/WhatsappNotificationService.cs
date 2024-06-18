using NotificationService.Services.Interfaces;
using Twilio;

namespace NotificationService.Services.Implementations;

public class WhatsAppNotificationStrategy : INotificationStrategy
{
    private readonly string _from;

    public WhatsAppNotificationStrategy(string accountId, string authToken, string from)
    {
        TwilioClient.Init(accountId, authToken);
        _from = from;
    }

    public async Task SendMessageAsync(string recipient, string message)
    {
        // await MessageResource.CreateAsync(
        //     body: message,
        //     from: new PhoneNumber($"Whatsapp:{_from}"), 
        //     to: new PhoneNumber($"Whatsapp:{recipient}")
        // );
    }
}