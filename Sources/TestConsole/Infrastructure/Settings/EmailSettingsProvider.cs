using System;
using System.IO;
using System.IO.Abstractions;
using Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.Settings
{
    public class EmailSettingsProvider : ISmtpSettingsProvider, IImapSettingsProvider
    {
        private readonly IDropboxLocator _dropboxLocator;
        private readonly IFileSystem _fileSystem;

        public EmailSettingsProvider(
            IFileSystem fileSystem,
            IDropboxLocator dropboxLocator)
        {
            _fileSystem = fileSystem;
            _dropboxLocator = dropboxLocator;
        }

        public ImapSettings ProvideImapSettings()
        {
#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
            var (userName, password) = ReadEmailCredentials();
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
            return new ImapSettings("outlook.office365.com", 993, userName, password);
        }

        public SmtpSettings ProvideSmtpSettings()
        {
#pragma warning disable SA1008 // Opening parenthesis must be spaced correctly
            var (userName, password) = ReadEmailCredentials();
#pragma warning restore SA1008 // Opening parenthesis must be spaced correctly
            return new SmtpSettings("SMTP.office365.com", 587, userName, password);
        }

        private(string, string) ReadEmailCredentials()
        {
            var dropboxPath =
                _dropboxLocator
                    .LocateDropboxPath()
                    .Reduce(() => throw new Exception("Could not locate Dropbox path"));

            var appPath = _fileSystem.Path.Combine(dropboxPath, @"Apps\ApplicationExtensions\settings.txt");

            var text = File.ReadAllLines(appPath);

            return (text[0], text[1]);
        }
    }
}