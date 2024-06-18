using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using NotificationService.Data;
using NotificationService.Services.Interfaces;

namespace NotificationService.Services.Implementations;

public class NotificationStrategy(NotificationContext context) : INotificationStrategy
{
    private readonly NotificationContext _context = context;
    private EmailService _emailService = new EmailService();
    private readonly IMessageService _messageService;

    public void Notify()
    {
        _emailService.SendMessage("Message");
    }

    public void NotifyAll()
    {
        _emailService.SendMessage("Message");
    }

    // public NotificationStrategy(IMessageService messageService)
    // {
    //     _messageService = messageService;
    // }

    public async Task SendPhoneNumberNotificationAsync(string sender, int senderPhoneNumber, string message,
        string recipient, int recipientPhoneNumber)
    {
        var phoneNumberRegex = "^[0-9]";
        if (!Regex.IsMatch(recipientPhoneNumber.ToString(), phoneNumberRegex))
        {
            throw new ArgumentException("invalid phone number: " + nameof(recipientPhoneNumber));
        }

        await Task.CompletedTask;
    }

    public async Task SendEmailNotificationAsync(string sender, string message, string recipient)
    {
        var email = new EmailAddressAttribute();
        if (!email.IsValid(recipient))
        {
            throw new ArgumentException("Invalid email address", nameof(recipient));
        }

        var mailMessage = new MailMessage(sender, recipient)
        {
            Subject = "Notification",
            Body = message,
            IsBodyHtml = false
        };

        using var smtpClient = new SmtpClient("smtp.gmail.com", 587);
        smtpClient.Credentials = new NetworkCredential("armsimonyan1.4.2005@gmail.com", "-password-");
        smtpClient.EnableSsl = true;
        await smtpClient.SendMailAsync(mailMessage);
    }

    public Task SendMessageAsync(string recipient, string message)
    {
        throw new NotImplementedException();
    }


    interface IMessageService
    {
        void SendMessage(string message);
    }

    class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Email : " + message);
        }
    }

    class TelegramService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Telegram: " + message);
        }
    }
}