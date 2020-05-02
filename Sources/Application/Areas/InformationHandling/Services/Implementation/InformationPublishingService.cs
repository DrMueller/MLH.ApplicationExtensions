using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class InformationPublishingService : IInformationPublishingService
    {
        private readonly IInformationSubscriptionService _configurationService;
        private readonly Queue<InformationEntry> _informationEntriesQueue = new Queue<InformationEntry>();
        private bool _publishingInProgress;

        public InformationPublishingService(IInformationSubscriptionService configurationService)
        {
            _configurationService = configurationService;
        }

        public void Publish(InformationEntry informationEntry)
        {
            _informationEntriesQueue.Enqueue(informationEntry);
            CheckAndPublish();
        }

        private void CheckAndPublish()
        {
            if (!_informationEntriesQueue.Any() || _publishingInProgress)
            {
                return;
            }

            _publishingInProgress = true;

            var nextEntry = _informationEntriesQueue.Dequeue();
            _configurationService.Subscribers.ForEach(subs => subs.Invoke(nextEntry));

            if (nextEntry.LengthInSeconds.HasValue)
            {
                Task.Run(
                    async () =>
                    {
                        await Task.Delay(nextEntry.LengthInSeconds.Value * 1000);
                        var emptyInfo = InformationEntry.CreateEmpty();
                        _configurationService.Subscribers.ForEach(subs => subs.Invoke(emptyInfo));
                        _publishingInProgress = false;
                        CheckAndPublish();
                    });
            }
            else
            {
                _publishingInProgress = false;
            }
        }
    }
}