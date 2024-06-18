using NotificationService.Services.Interfaces;
using Telegram.Bot;

namespace NotificationService.Services.Implementations;

public class TelegramNotificationStrategy : INotificationStrategy
{
    private readonly TelegramBotClient _botClient;
    private readonly int _chatId;

    public TelegramNotificationStrategy(string token, int chatId)
    {
        _botClient = new TelegramBotClient(token);
        _chatId = chatId;
    }

    public async Task SendMessageAsync(string recipient, string message)
    {
        await _botClient.SendTextMessageAsync(_chatId, message);
    }
}