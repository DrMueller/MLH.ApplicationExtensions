using System;
using System.Net.Mail;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants
{
    internal interface ISmtpClientProxy : IDisposable
    {
        void Send(MailMessage mailMessage);
    }
}