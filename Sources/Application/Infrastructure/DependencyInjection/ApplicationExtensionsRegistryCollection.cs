using System.IO.Abstractions;
using Lamar;
using Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services.Implementation;

namespace Mmu.Mlh.ApplicationExtensions.Infrastructure.DependencyInjection
{
    public class ApplicationExtensionsRegistryCollection : ServiceRegistry
    {
        public ApplicationExtensionsRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ApplicationExtensionsRegistryCollection>();
                    scanner.WithDefaultConventions();
                });

            // Dropbox - Locator
            For<IDropboxLocator>().Use<DropboxLocator>().Singleton();

            // E-Mails - Imap
            For<IImapEmailReceiver>().Use<ImapEmailReceiver>().Singleton();
            For<IImapClientProxy>().Use<ImapClientProxy>().Singleton();
            For<IImapClientProxyFactory>().Use<ImapClientProxyFactory>().Singleton();

            // E-Mails - Sending
            For<IEmailSender>().Use<EmailSender>().Singleton();
            For<ISmtpClientProxy>().Use<SmtpClientProxy>().Singleton();
            For<ISmtpClientProxyFactory>().Use<SmtpClientProxyFactory>().Singleton();

            // Information handling
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationPublishingService>().Use<InformationPublishingService>().Singleton();

            // Infrastructure
            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}