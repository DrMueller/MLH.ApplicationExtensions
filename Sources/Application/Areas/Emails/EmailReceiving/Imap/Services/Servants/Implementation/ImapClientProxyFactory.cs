using System.Threading.Tasks;
using MailKit.Net.Imap;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants.Implementation
{
    internal class ImapClientProxyFactory : IImapClientProxyFactory
    {
        private readonly ImapSettings _settings;

        public ImapClientProxyFactory(IImapSettingsProvider settingsProvider)
        {
            _settings = settingsProvider.ProvideImapSettings();
        }

        public async Task<IImapClientProxy> CreateAuthenticatedProxyAsync()
        {
#pragma warning disable CA5359 // Do Not Disable Certificate Validation
            var client = new ImapClient { ServerCertificateValidationCallback = (s, c, h, e) => true };
#pragma warning restore CA5359 // Do Not Disable Certificate Validation

            await client.ConnectAsync(_settings.Host, _settings.Port, true);
            await client.AuthenticateAsync(_settings.UserName, _settings.Password);

            return new ImapClientProxy(client);
        }
    }
}