using Microsoft.AspNetCore.Http;

namespace Application.EmailServices;

public interface IEmailService
{
    Task SendEmailAsync(string to, string subject, string content, IList<IFormFile> attachments = default!);
}