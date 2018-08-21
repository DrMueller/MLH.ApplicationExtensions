using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning.Implementation;
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

            For<IProvisioningService>().Use<ProvisioningService>();

            // Rest
            For<IRestProxy>().Use<RestProxy>();

            // Information handling
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationPublishingService>().Use<InformationPublishingService>().Singleton();
        }
    }
}