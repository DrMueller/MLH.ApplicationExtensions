using System.IO;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services;
using Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.Dropbox;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.Settings
{
    public class ImapSettingsProvider : IImapSettingsProvider
    {
        public ImapSettings ProvideImapSettings()
        {
            var readResult = DropboxLocator.LocateDropboxSettingsPath();
            var text = File.ReadAllLines(readResult.Value);
            return new ImapSettings("outlook.office365.com", 993, text[0], text[1]);
        }
    }
}