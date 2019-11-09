using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services.Servants.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.ApplicationExtensions.Infrastructure.DependencyInjection
{
    public class ApplicationExtensionsRegistry : Registry
    {
        public ApplicationExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ApplicationExtensionsRegistry>();
                    scanner.WithDefaultConventions();
                });

            // E-Mails - Imap
            For<IImapEmailReceiver>().Use<ImapEmailReceiver>().Singleton();
            For<IImapClientProxy>().Use<ImapClientProxy>().Singleton();

            // E-Mails - Sending
            For<IEmailSender>().Use<EmailSender>().Singleton();
            For<ISmtpClientProxy>().Use<SmtpClientProxy>().Singleton();

            // Information handling
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationPublishingService>().Use<InformationPublishingService>().Singleton();
        }
    }
}