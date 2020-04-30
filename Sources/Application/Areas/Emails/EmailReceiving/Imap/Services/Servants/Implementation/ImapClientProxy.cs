using System;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants.Implementation
{
    internal class ImapClientProxy : IImapClientProxy
    {
        private readonly ImapClient _imapClient;
        private bool _disposed;
        public IMailFolder Inbox => _imapClient.Inbox;

        public ImapClientProxy(ImapClient imapClient)
        {
            _imapClient = imapClient;
        }

        public async Task DisconnectAsync()
        {
            await _imapClient.DisconnectAsync(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposedByCode)
        {
            if (!_disposed)
            {
                if (disposedByCode)
                {
                    _imapClient.Dispose();
                }

                _disposed = true;
            }
        }

        ~ImapClientProxy()
        {
            Dispose(false);
        }
    }
}