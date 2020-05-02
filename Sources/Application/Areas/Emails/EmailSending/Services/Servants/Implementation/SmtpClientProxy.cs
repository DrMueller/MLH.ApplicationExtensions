using System;
using System.Net.Mail;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants.Implementation
{
    internal sealed class SmtpClientProxy : ISmtpClientProxy
    {
        private readonly SmtpClient _smtpClient;
        private bool _disposed;

        public SmtpClientProxy(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        ~SmtpClientProxy()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Send(MailMessage mailMessage)
        {
            _smtpClient.Send(mailMessage);
        }

        private void Dispose(bool disposedByCode)
        {
            if (_disposed)
            {
                return;
            }

            if (disposedByCode)
            {
                _smtpClient.Dispose();
            }

            _disposed = true;
        }
    }
}