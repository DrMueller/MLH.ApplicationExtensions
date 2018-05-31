using System;
using System.Linq;
using System.Reflection;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Handlers;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.ApplicationExtensions.Infrastructure.Informations;
using Mmu.Mlh.LanguageExtensions.Infrastructure.DependencyInjection;
using StructureMap;
using StructureMap.Graph;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection
{
    public static class ContainerInitializationService
    {
        public static Container CreateInitializedContainer(Assembly rootAssembly)
        {
            var result = new Container();

            result.Configure(
                config =>
                {
                    config.Scan(
                        scanner =>
                        {
                            AddReferencedAssemblies(scanner, rootAssembly);
                            scanner.LookForRegistries();
                        });
                });

            InformationService.DebugMessage("Container WhatDidIScan:" + result.WhatDidIScan());
            InformationService.DebugMessage("Container WhatDoIHave:" + result.WhatDoIHave());

            var provisioningService = result.GetInstance<IProvisioningService>();
            ProvisioningServiceSingleton.Initialize(provisioningService);
            return result;
        }

        private static void AddReferencedAssemblies(IAssemblyScanner scanner, Assembly rootAssembly)
        {
            scanner.Assembly(rootAssembly);

            // Not sure, why we need to do this tbh
            scanner.Assembly(typeof(LanguageExtensionsRegistry).Assembly);
            var references = AssemblyReferencesFetcher.FetchReferences(rootAssembly);

            InformationService.DebugMessage(
                "Adding Assemblies to scan: " +
                Environment.NewLine +
                string.Join(Environment.NewLine, references.Select(f => f.FullName)));

            foreach (var reference in references)
            {
                scanner.Assembly(reference);
            }
        }
    }
}