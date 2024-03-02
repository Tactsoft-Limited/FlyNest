namespace FlyNest.SharedKernel.Core.EmailService;

public interface IMailService
{
    void SendEmail(Message request);
    Task SendEmailAsync(Message request);
}
