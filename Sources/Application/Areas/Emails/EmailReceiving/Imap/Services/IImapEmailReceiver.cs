﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services
{
    public interface IImapEmailReceiver
    {
        Task<IReadOnlyCollection<Email>> ReceiveFromInboxAsync();
    }
}