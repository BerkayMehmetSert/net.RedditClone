using Infrastructure.EmailService.Model;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.EmailService.Builder;

public class EmailContentBuilder : IEmailContentBuilder
{
    private readonly EmailOptions _emailOptions;

    public EmailContentBuilder(IOptionsMonitor<EmailOptions> emailOptions)
    {
        _emailOptions = emailOptions.CurrentValue;
    }

    public MimeMessage Build(EmailMessage emailMessage)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("email", _emailOptions.From));
        message.To.Add(emailMessage.To);
        message.Subject = emailMessage.Subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = emailMessage.Content
        };
        return message;
    }
}