using System.IO.Abstractions;
using Lamar;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services;
using Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.Settings;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.DependencyInjection
{
    public class TestConsoleRegistryCollection : ServiceRegistry
    {
        public TestConsoleRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(TestConsoleRegistryCollection));
                    scanner.WithDefaultConventions();

                    scanner.AddAllTypesOf<IConsoleCommand>();
                });

            For<ISmtpSettingsProvider>().Use<EmailSettingsProvider>().Singleton();
            For<IImapSettingsProvider>().Use<EmailSettingsProvider>().Singleton();
            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}