using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services.Implementation;
using StructureMap;

namespace Mmu.Mlh.ApplicationExtensions.Infrastructure.DependencyInjection
{
    public class ApplicationExtensionsRegistry : Registry
    {
        public ApplicationExtensionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ApplicationExtensionsRegistry>();
                    scanner.WithDefaultConventions();
                });

            // Information handling
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationPublishingService>().Use<InformationPublishingService>().Singleton();
        }
    }
}