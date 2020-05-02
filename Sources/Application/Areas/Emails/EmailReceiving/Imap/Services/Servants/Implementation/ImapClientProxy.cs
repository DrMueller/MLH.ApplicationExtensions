using System;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants.Implementation
{
    internal sealed class ImapClientProxy : IImapClientProxy
    {
        private readonly ImapClient _imapClient;
        private bool _disposed;

        public ImapClientProxy(ImapClient imapClient)
        {
            _imapClient = imapClient;
        }

        ~ImapClientProxy()
        {
            Dispose(false);
        }

        public IMailFolder Inbox => _imapClient.Inbox;

        public async Task DisconnectAsync()
        {
            await _imapClient.DisconnectAsync(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposedByCode)
        {
            if (_disposed)
            {
                return;
            }

            if (disposedByCode)
            {
                _imapClient.Dispose();
            }

            _disposed = true;
        }
    }
}