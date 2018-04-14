﻿using System.Diagnostics;
using System.Reflection;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Handlers;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using StructureMap;
using StructureMap.Graph;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection
{
    public static class ContainerInitializationService
    {
        public static Container CreateInitializedContainer(
            Assembly rootAssembly)
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

            var provisioningService = result.GetInstance<IProvisioningService>();
            ProvisioningServiceSingleton.Initialize(provisioningService);
            return result;
        }

        private static void AddReferencedAssemblies(IAssemblyScanner scanner, Assembly rootAssembly)
        {
            scanner.Assembly(rootAssembly);

            // Not sure, ehy we need to do this tbh
            scanner.Assembly(typeof(LanguageExtensions.Infrastructure.DependencyInjection.LanguageExtensionsRegistry).Assembly);
            var references = AssemblyReferencesFetcher.FetchReferences(rootAssembly);
            foreach (var reference in references)
            {
                Debug.WriteLine(reference);
                scanner.Assembly(reference);
            }
        }
    }
}