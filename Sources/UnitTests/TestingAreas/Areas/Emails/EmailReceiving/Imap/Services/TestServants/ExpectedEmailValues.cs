using System.Collections.Generic;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailReceiving.Imap.Services.TestServants
{
    internal class ExpectedEmailValues
    {
        public string BodyText { get; }
        public IReadOnlyCollection<string> FromEmailAddresses { get; }
        public string Subject { get; }
        public IReadOnlyCollection<string> ToEmailAddresses { get; }

        public ExpectedEmailValues(
            IReadOnlyCollection<string> fromEmailAddresses,
            IReadOnlyCollection<string> toEmailAddresses,
            string subject,
            string bodyTest)
        {
            FromEmailAddresses = fromEmailAddresses;
            ToEmailAddresses = toEmailAddresses;
            Subject = subject;
            BodyText = bodyTest;
        }
    }
}