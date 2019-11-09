using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models
{
    public class Email
    {
        public IReadOnlyCollection<string> FromAddresses { get; }
        public string Subject { get; }
        public string Body { get; }

        public Email(
            IReadOnlyCollection<string> fromAddresses,
            string subject,
            string body)
        {
            Guard.CollectionNotNullOrEmpty(() => fromAddresses);
            Guard.StringNotNullOrEmpty(() => subject);

            FromAddresses = fromAddresses;
            Subject = subject;
            Body = body;
        }
    }
}