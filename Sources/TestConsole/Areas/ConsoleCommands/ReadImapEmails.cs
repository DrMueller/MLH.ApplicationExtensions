using System;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Areas.ConsoleCommands
{
    public class ReadImapEmails : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IImapEmailReceiver _imapEmailReceiver;
        public string Description => "Read E-Mails via IMAP";

        public ConsoleKey Key => ConsoleKey.F1;

        public ReadImapEmails(IImapEmailReceiver imapEmailReceiver, IConsoleWriter consoleWriter)
        {
            _imapEmailReceiver = imapEmailReceiver;
            _consoleWriter = consoleWriter;
        }

        public async Task ExecuteAsync()
        {
            var emails = await _imapEmailReceiver.ReceiveFromInboxAsync();

            _consoleWriter.WriteLine($"Found {emails.Count} E-Mails");

            var sb = new StringBuilder();
            emails.ForEach(email =>
            {
                sb.Append("Subject: ");
                sb.AppendLine(email.Subject);
                sb.Append("From: ");
                sb.AppendLine(string.Join(", ", email.FromAddresses));
                sb.Append("To: ");
                sb.AppendLine(string.Join(", ", email.ToAddresses));
                sb.Append("Body: ");
                sb.AppendLine(email.Body);
            });

            _consoleWriter.WriteLine(sb.ToString());
        }
    }
}