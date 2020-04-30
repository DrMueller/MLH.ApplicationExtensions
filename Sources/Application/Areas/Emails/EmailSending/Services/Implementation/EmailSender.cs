using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Implementation
{
    internal class EmailSender : IEmailSender
    {
        private readonly ISmtpClientProxyFactory _smtpClientProxyFactory;

        public EmailSender(ISmtpClientProxyFactory smtpClientProxyFactory)
        {
            _smtpClientProxyFactory = smtpClientProxyFactory;
        }

        public Task SendEmailAsync(Email email)
        {
            Guard.ObjectNotNull(() => email);

            return Task.Run(
                () =>
                {
                    var mailMessage = CreateMailMessage(email);

                    using (var smtpClient = _smtpClientProxyFactory.CreateProxy())
                    {
                        smtpClient.Send(mailMessage);
                    }
                });
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
    }
}