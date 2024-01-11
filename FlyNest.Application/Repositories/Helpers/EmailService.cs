using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FlyNest.Application.Repositories.Helpers;

public class EmailService
{
    private readonly IConfiguration _configuration;
    private readonly ISendGridClient _sendGridClient;

    public EmailService(IConfiguration configuration, ISendGridClient sendGridClient)
    {
        _configuration = configuration;
        _sendGridClient = sendGridClient;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string content)
    {
        var message = new SendGridMessage
        {
            From =
                new EmailAddress(
                    _configuration["EmailSettings:SenderEmail"],
                    _configuration["EmailSettings:SenderName"]),
            Subject = subject,
            PlainTextContent = content,
            HtmlContent = content
        };

        message.AddTo(new EmailAddress(toEmail));

        await _sendGridClient.SendEmailAsync(message);
    }
}

