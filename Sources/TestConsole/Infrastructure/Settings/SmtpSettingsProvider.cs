using System.IO;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Services;
using Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.Dropbox;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.Settings
{
    public class SmtpSettingsProvider : ISmtpSettingsProvider
    {
        public SmtpSettings ProvideSmtpSettings()
        {
            var readResult = DropboxLocator.LocateDropboxSettingsPath();
            var text = File.ReadAllLines(readResult.Value);

            return new SmtpSettings("SMTP.office365.com", 587, text[0], text[1]);
        }
    }
}