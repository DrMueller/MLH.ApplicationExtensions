using System;
using System.Threading.Tasks;
using MailKit;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants
{
    internal interface IImapClientProxy : IDisposable
    {
        IMailFolder Inbox { get; }

        Task DisconnectAsync();
    }
}