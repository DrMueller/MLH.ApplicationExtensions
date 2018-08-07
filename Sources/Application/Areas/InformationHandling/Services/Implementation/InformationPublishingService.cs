using System.Diagnostics.CodeAnalysis;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class InformationPublishingService : IInformationPublishingService
    {
        private readonly IInformationSubscriptionService _configurationService;

        public InformationPublishingService(IInformationSubscriptionService configurationService) => _configurationService = configurationService;

        public void Publish(InformationEntry informationEntry)
        {
            _configurationService.Subscribers.ForEach(subs => subs.Invoke(informationEntry));
        }
    }
}