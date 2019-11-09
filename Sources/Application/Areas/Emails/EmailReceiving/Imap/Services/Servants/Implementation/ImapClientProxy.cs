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

        public ImapClientProxy(ImapClient imapClient)
        {
            _imapClient = imapClient;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IMailFolder Inbox
        {
            get
            {
                return _imapClient.Inbox;
            }
        }

        public async Task DisconnectAsync()
        {
            await _imapClient.DisconnectAsync(true);
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