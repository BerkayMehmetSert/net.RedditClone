using MimeKit;

namespace Infrastructure.EmailService.Model;

public class EmailMessage
{
    public MailboxAddress To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }

    public EmailMessage(string to, string subject, string content)
    {
        To = new MailboxAddress("email", to);
        Subject = subject;
        Content = content;
    }
}