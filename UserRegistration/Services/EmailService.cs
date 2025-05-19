using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using UserRegistration.Configurations;

namespace UserRegistration.Services
{
    public class EmailService
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value;
        }

        public async Task SendRegistrationEmailAsync(string toEmail, string userName)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(_smtpSettings.FromEmail, _smtpSettings.AppPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.FromEmail),
                Subject = "Registration Successful",
                Body = $"<h3>Hello {userName},</h3><p>You have successfully registered to User Resigtration App!</p>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}