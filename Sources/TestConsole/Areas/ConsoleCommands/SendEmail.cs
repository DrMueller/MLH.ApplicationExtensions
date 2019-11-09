﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Areas.ConsoleCommands
{
    public class SendEmail : IConsoleCommand
    {
        private readonly IEmailSender _emailSender;
        public string Description => "Send E-Mail";
        public ConsoleKey Key => ConsoleKey.F2;

        public SendEmail(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task ExecuteAsync()
        {
            var email = new Email(
                "matthiasm@live.de",
                new List<string> { "matthias.mueller@trivadis.com" },
                "Test 124",
                new EmailBody("Hello there!", false));

            await _emailSender.SendEmailAsync(email);
        }
    }
}