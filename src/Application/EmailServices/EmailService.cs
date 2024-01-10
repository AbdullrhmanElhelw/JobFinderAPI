using Domain.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Application.EmailServices;

public class EmailService(IOptions<EmailSettings> emailSettings)
    : IEmailService
{
    private readonly EmailSettings _emailSettings = emailSettings.Value;

    public async Task SendEmailAsync(string to, string subject, string content, IList<IFormFile> attachments = null!)
    {
        var email = new MimeMessage
        {
            Sender = MailboxAddress.Parse(_emailSettings.Email),
            Subject = subject
        };

        email.To.Add(MailboxAddress.Parse(to));

        var builder = new BodyBuilder
        {
            HtmlBody = content
        };

        if (attachments != null && attachments.Any())
        {
            foreach (var file in attachments)
            {
                if (file.Length > 0)
                {
                    using var ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    builder.Attachments.Add(file.FileName, ms.ToArray(), ContentType.Parse(file.ContentType));
                }
            }
        }

        email.Body = builder.ToMessageBody();
        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}

#region Sending Email Steps

// 1. create a MimeMessage object
// 2. add sender and receiver
// 3. create a BodyBuilder object
// 4. add content to the BodyBuilder object
// 5. add the BodyBuilder object to the MimeMessage object
// 6. create a SmtpClient object
// 7. connect to the SMTP server
// 8. authenticate with the SMTP server
// 9. send the email
// 10. disconnect from the SMTP server

#endregion Sending Email Steps