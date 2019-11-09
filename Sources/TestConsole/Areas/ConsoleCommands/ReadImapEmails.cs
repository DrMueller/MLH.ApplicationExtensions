using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Areas.ConsoleCommands
{
    public class ReadImapEmails : IConsoleCommand
    {
        private readonly IImapEmailReceiver _imapEmailReceiver;

        public string Description => "Read E-Mails via IMAP";

        public ConsoleKey Key => ConsoleKey.F1;

        public ReadImapEmails(IImapEmailReceiver imapEmailReceiver)
        {
            _imapEmailReceiver = imapEmailReceiver;
        }

        public async Task ExecuteAsync()
        {
            await _imapEmailReceiver.ReceiveFromInboxAsync();
        }
    }
}