using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MimeKit;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.Emails.EmailReceiving.Imap.Services.TestServants
{
    internal static class MimeMessageFactory
    {
        internal static MimeMessage CreateTestMimeMessage(out ExpectedEmailValues expectedEmailValues)
        {
            var fromEmailAddresses = new List<string> { "from1@gmx.ch", "from2@fake.com" };

            var toEmailAddresses = new List<string> { "to1@gmx.ch", "to2@fake.com" };

            var from = fromEmailAddresses.Select(adr => new MailboxAddress(adr, adr)).ToList();
            var to = toEmailAddresses.Select(adr => new MailboxAddress(adr, adr)).ToList();
            var bodyText = CreateBodyText();

            const string Subject = "Subject1234";
            using (var ms = new MemoryStream())
            using (var sw = new StreamWriter(ms))
            {
                sw.Write(bodyText);
                sw.Flush();
                ms.Seek(0, SeekOrigin.Begin);

                var body = MimeEntity.Load(ms);
                var mimeMessage = new MimeMessage(from, to, Subject, body);

                expectedEmailValues = new ExpectedEmailValues(fromEmailAddresses, toEmailAddresses, Subject, bodyText);
                return mimeMessage;
            }
        }

        private static string CreateBodyText()
        {
            var sb = new StringBuilder();

            sb.AppendLine("Content-Language: aa");
            sb.AppendLine("Content-Type: multipart/alternative;");
            sb.AppendLine("boundary=\"_000_AM6PR05MB44073DB9AC17595EE30F79FAE87A0AM6PR05MB4407eurp_\"");
            sb.AppendLine("--_000_AM6PR05MB44073DB9AC17595EE30F79FAE87A0AM6PR05MB4407eurp_");
            sb.AppendLine("Content-Type: text/plain; charset=\"iso-8859-1\"");
            sb.AppendLine("Content-Transfer-Encoding: quoted-printable");
            sb.AppendLine(string.Empty);
            sb.AppendLine("Hello world");

            return sb.ToString();
        }
    }
}