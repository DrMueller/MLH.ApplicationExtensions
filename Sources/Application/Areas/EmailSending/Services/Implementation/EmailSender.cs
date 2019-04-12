using System.Net;
using System.Net.Mail;
using System.Text;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Services.Implementation
{
    public class EmailSender : IEmailSender
    {
        private readonly ISmtpSettingsProvider _settingsProvider;

        public EmailSender(ISmtpSettingsProvider settingsProvider)
        {
            _settingsProvider = settingsProvider;
        }

        public void SendEmail(Email email)
        {
            Guard.ObjectNotNull(() => email);
            var mailMessage = CreateMailMessage(email);

            using (var smtpClient = CreateSmtpClient())
            {
                smtpClient.Send(mailMessage);
            }
        }

        private static MailMessage CreateMailMessage(Email email)
        {
            var mailMessage = new MailMessage { From = new MailAddress(email.FromAddress) };

            email.ToAddresses.ForEach(f => mailMessage.To.Add(f));
            mailMessage.Subject = email.Subject;
            mailMessage.Body = email.Body.Content;
            mailMessage.IsBodyHtml = email.Body.IsHtmlBody;
            mailMessage.BodyEncoding = Encoding.UTF8;

            return mailMessage;
        }

        private SmtpClient CreateSmtpClient()
        {
            var smtpSettings = _settingsProvider.ProvideSmtpSettings();

            var smtpClient = new SmtpClient(smtpSettings.Host, smtpSettings.Port)
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(smtpSettings.UserName, smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            return smtpClient;
        }
    }
}