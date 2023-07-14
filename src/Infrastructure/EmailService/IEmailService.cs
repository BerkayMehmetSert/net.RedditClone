using Infrastructure.EmailService.Model;

namespace Infrastructure.EmailService;

public interface IEmailService
{
    void SendEmail(EmailMessage emailMessage);
}