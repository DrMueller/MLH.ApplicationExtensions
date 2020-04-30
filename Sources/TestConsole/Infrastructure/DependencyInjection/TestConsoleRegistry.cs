using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services;
using Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.Settings;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using StructureMap;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Infrastructure.DependencyInjection
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType(typeof(TestConsoleRegistry));
                    scanner.WithDefaultConventions();

                    scanner.AddAllTypesOf<IConsoleCommand>();
                });

            For<ISmtpSettingsProvider>().Use<SmtpSettingsProvider>().Singleton();
        }
    }
}