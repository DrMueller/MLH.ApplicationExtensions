using System;
using System.Reflection;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Handlers;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using StructureMap;
using StructureMap.Graph;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection
{
    public static class ContainerInitializationService
    {
        public static Container CreateInitializedContainer(
            Assembly rootAssembly,
            Maybe<Action<IAssemblyScanner>> onScanning,
            Maybe<Action<ConfigurationExpression>> onConfiguring)
        {
            var result = new Container();

            result.Configure(
                config =>
                {
                    config.Scan(
                        scanner =>
                        {
                            scanner.AssemblyContainingType(typeof(ContainerInitializationService));
                            AddReferencedAssemblies(scanner, rootAssembly);
                            scanner.LookForRegistries();
                            scanner.WithDefaultConventions();

                            onScanning.Evaluate(scanAction => scanAction.Invoke(scanner));
                        });

                    onConfiguring.Evaluate(configAction => configAction.Invoke(config));
                });

            return result;
        }

        private static void AddReferencedAssemblies(IAssemblyScanner scanner, Assembly rootAssembly)
        {
            scanner.Assembly(rootAssembly);

            var references = AssemblyReferencesFetcher.FetchReferences(rootAssembly);
            foreach (var reference in references)
            {
                scanner.Assembly(reference);
            }
        }
    }
}