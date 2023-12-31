using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace FlyNest.Application.Repositories.Helpers;

public class EmailSender : IEmailSender
{
    private readonly SmtpClient _smtpClient;

    public EmailSender()
    {
        // Configure your SMTP settings here
        _smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential("tactsoft01@gmail.com", "Tactsoft9805"),
            EnableSsl = true,
        };
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress("tactsoft01@gmail.com"),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true,
        };

        mailMessage.To.Add(email);

        return _smtpClient.SendMailAsync(mailMessage);
    }
}