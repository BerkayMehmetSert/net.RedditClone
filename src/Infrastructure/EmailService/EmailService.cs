using Infrastructure.EmailService.Builder;
using Infrastructure.EmailService.Model;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.EmailService;

public class EmailService : IEmailService
{
    private readonly IEmailContentBuilder _builder;
    private readonly EmailOptions _emailOptions;

    public EmailService(IEmailContentBuilder builder, IOptionsMonitor<EmailOptions> emailOptions)
    {
        _builder = builder;
        _emailOptions = emailOptions.CurrentValue;
    }

    public void SendEmail(EmailMessage emailMessage)
    {
        var message = _builder.Build(emailMessage);
        Send(message);
    }

    private void Send(MimeMessage message)
    {
        using var client = new SmtpClient();
        client.Connect(_emailOptions.SmtpServer, _emailOptions.Port, true);
        client.AuthenticationMechanisms.Remove("XOAUTH2");
        client.Authenticate(_emailOptions.UserName, _emailOptions.Password);
        client.Send(message);
        client.Disconnect(true);
    }
}