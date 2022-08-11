using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models
{
    public class Email
    {
        public Email(string fromAddress, IReadOnlyCollection<string> toAddresses, string subject, EmailBody body)
        {
            Guard.StringNotNullOrEmpty(() => fromAddress);
            Guard.ObjectNotNull(() => toAddresses);
            Guard.That(() => toAddresses.Count > 0, "E-Mail must have at least one TO-Address");
            Guard.StringNotNullOrEmpty(() => subject);
            Guard.ObjectNotNull(() => body);

            FromAddress = fromAddress;
            ToAddresses = toAddresses;
            Subject = subject;
            Body = body;
        }

        public EmailBody Body { get; }
        public string FromAddress { get; }
        public string Subject { get; }
        public IReadOnlyCollection<string> ToAddresses { get; }
    }
}