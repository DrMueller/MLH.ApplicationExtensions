using System.Net;
using System.Net.Mail;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants.Implementation
{
    internal class SmtpClientProxyFactory : ISmtpClientProxyFactory
    {
        private readonly SmtpSettings _smtpSettings;

        public SmtpClientProxyFactory(ISmtpSettingsProvider smtpSettingsprovider)
        {
            _smtpSettings = smtpSettingsprovider.ProvideSmtpSettings();
        }

        public ISmtpClientProxy CreateProxy()
        {
            var smtpClient = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
            {
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };

            return new SmtpClientProxy(smtpClient);
        }
    }
}