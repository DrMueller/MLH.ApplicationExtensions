using System;
using System.Collections.Generic;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services
{
    public interface IInformationSubscriptionService
    {
        IReadOnlyCollection<Action<InformationEntry>> Subscribers { get; }

        void RegisterSubscriber(Action<InformationEntry> subscriber);
    }
}