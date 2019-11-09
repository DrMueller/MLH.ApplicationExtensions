﻿using System;
using System.Net.Mail;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants.Implementation
{
    internal class SmtpClientProxy : ISmtpClientProxy
    {
        private readonly SmtpClient _smtpClient;
        private bool _disposed;

        public SmtpClientProxy(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
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

        protected virtual void Dispose(bool disposedByCode)
        {
            if (!_disposed)
            {
                if (disposedByCode)
                {
                    _smtpClient.Dispose();
                }

                _disposed = true;
            }
        }

        ~SmtpClientProxy()
        {
            Dispose(false);
        }
    }
}