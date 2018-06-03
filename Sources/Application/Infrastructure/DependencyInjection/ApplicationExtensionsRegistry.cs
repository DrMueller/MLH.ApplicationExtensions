using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies;
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
                    scanner.AddAllTypesOf<IRestCallStrategy>();
                    scanner.WithDefaultConventions();
                });

            For<IProvisioningService>().Use<ProvisioningService>();
        }
    }
}