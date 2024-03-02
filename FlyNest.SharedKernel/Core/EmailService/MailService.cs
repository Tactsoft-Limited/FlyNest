using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.ServiceModel.Channels;

namespace FlyNest.SharedKernel.Core.EmailService;

public class MailService(IOptions<MailSetting> mailConfig) : IMailService
{
    private readonly MailSetting _mailConfig = mailConfig.Value;

    public void SendEmail(Message request)
    {
        var emailMessage = CreateEmailMessage(request);
        Send(emailMessage);
    }

    public async Task SendEmailAsync(Message request)
    {
        var mailMessage = CreateEmailMessage(request);
        await SendAsync(mailMessage);
    }

    private MimeMessage CreateEmailMessage(Message message)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress(_mailConfig.SenderName, _mailConfig.SenderEmail));
        emailMessage.To.AddRange(message.To);
        emailMessage.Subject = message.Subject;
        //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
        var bodyBuilder = new BodyBuilder { HtmlBody = $"<h2 style='color:Black;'>{message.Content}</h2>" };

        if (message.Attachments != null && message.Attachments.Any())
        {
            byte[] fileBytes;
            foreach (var attachment in message.Attachments)
            {
                using (var ms = new MemoryStream())
                {
                    attachment.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
                bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
            }
        }

        emailMessage.Body = bodyBuilder.ToMessageBody();

        return emailMessage;
    }

    private void Send(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            client.Connect(_mailConfig.Server, _mailConfig.Port, _mailConfig.UseSSL);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate(_mailConfig.UserName, _mailConfig.Password);
            client.Send(mailMessage);
        }
        catch (Exception)
        {
            //log an error message or throw an exception or both.
            throw;
        }
        finally
        {
            client.Disconnect(true);
            client.Dispose();
        }
    }
    private async Task SendAsync(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_mailConfig.Server, _mailConfig.Port, _mailConfig.UseSSL);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_mailConfig.UserName, _mailConfig.Password);
            await client.SendAsync(mailMessage);
        }
        catch (Exception)
        {
            //log an error message or throw an exception, or both.
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }
}
