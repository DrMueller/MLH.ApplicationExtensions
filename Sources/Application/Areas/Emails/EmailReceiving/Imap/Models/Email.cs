﻿using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models
{
    public class Email
    {
        public Email(
            IReadOnlyCollection<string> fromAddresses,
            IReadOnlyCollection<string> toAddresses,
            string subject,
            string body)
        {
            Guard.CollectionNotNullOrEmpty(() => fromAddresses);
            Guard.CollectionNotNullOrEmpty(() => toAddresses);
            Guard.StringNotNullOrEmpty(() => subject);

            FromAddresses = fromAddresses;
            ToAddresses = toAddresses;
            Subject = subject;
            Body = body;
        }

        public string Body { get; }
        public IReadOnlyCollection<string> FromAddresses { get; }
        public string Subject { get; }
        public IReadOnlyCollection<string> ToAddresses { get; }
    }
}