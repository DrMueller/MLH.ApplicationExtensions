using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.InformationHandling.Services.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies.Implementation;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies.Servants;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies.Servants.Implementation;
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
            For<IRestProxy>().Use<RestProxy>().Singleton();
            For<IRestCallBuilderFactory>().Use<RestCallBuilderFactory>().Singleton();
            For<IHttpRequestFactory>().Use<HttpRequestFactory>().Singleton();

            // Information handling
            For<IInformationSubscriptionService>().Use<InformationSubscriptionService>().Singleton();
            For<IInformationPublishingService>().Use<InformationPublishingService>().Singleton();
        }
    }
}