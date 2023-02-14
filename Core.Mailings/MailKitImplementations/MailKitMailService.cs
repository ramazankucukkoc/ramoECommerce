using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
namespace Core.Mailings.MailKitImplementations
{
    public class MailKitMailService : IMailService
    {
        private IConfiguration _configuration;
        private readonly MailSettings _mailSettings;

        public MailKitMailService(IConfiguration configuration)
        {
            _configuration = configuration;
            _mailSettings = _configuration.GetSection("MailSettings").Get<MailSettings>();
        }

        public void SendMail(Mail mail)
        {
            MimeMessage email = new();

            email.From.Add(new MailboxAddress(_mailSettings.SenderFullName, _mailSettings.SenderEmail));//gönderen

            email.To.Add(new MailboxAddress(mail.ToFullName, mail.ToEmail));//alıcı

            email.Subject = mail.Subject;

            BodyBuilder bodyBuilder = new()
            {
                TextBody = mail.TextBody,
                HtmlBody = mail.HtmlBody
            };

            if (mail.Attachments != null)
                foreach (MimeEntity? attachment in mail.Attachments)
                    bodyBuilder.Attachments.Add(attachment);

            email.Body = bodyBuilder.ToMessageBody();

            using SmtpClient smtp = new();
            smtp.Connect(_mailSettings.Server, _mailSettings.Port, MailKit.Security.SecureSocketOptions.Auto);
            smtp.Authenticate(_mailSettings.UserName, "Ramazan45.?");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}