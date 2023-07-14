using Infrastructure.EmailService.Model;
using MimeKit;

namespace Infrastructure.EmailService.Builder;

public interface IEmailContentBuilder
{
    MimeMessage Build(EmailMessage emailMessage);
}