using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services
{
    public interface IInformationPublishingService
    {
        void Publish(InformationEntry informationEntry);
    }
}