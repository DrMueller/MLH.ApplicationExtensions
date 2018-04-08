using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies;
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
        }
    }
}