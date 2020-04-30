using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services
{
    public interface IImapSettingsProvider
    {
        ImapSettings ProvideImapSettings();
    }
}