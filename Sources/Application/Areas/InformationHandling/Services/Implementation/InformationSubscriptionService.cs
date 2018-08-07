using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class InformationSubscriptionService : IInformationSubscriptionService
    {
        private readonly List<Action<InformationEntry>> _subscribers = new List<Action<InformationEntry>>();

        public IReadOnlyCollection<Action<InformationEntry>> Subscribers => _subscribers;

        public void RegisterSubscriber(Action<InformationEntry> subscriber)
        {
            _subscribers.Add(subscriber);
        }
    }
}