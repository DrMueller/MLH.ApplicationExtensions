using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Handlers
{
    internal static class AssemblyReferencesFetcher
    {
        internal static IReadOnlyCollection<Assembly> FetchReferences(Assembly assembly)
        {
            var result = new List<Assembly>();
            GetReferences(assembly, result);

            return result;
        }

        private static void GetReferences(Assembly sourceAssembly, ICollection<Assembly> references)
        {
            foreach (var assemblyName in sourceAssembly.GetReferencedAssemblies())
            {
                var loadedAssembly = Assembly.Load(assemblyName);

                ////var referencedAssembly = AppDomain
                ////    .CurrentDomain
                ////    .GetAssemblies()
                ////    .SingleOrDefault(a => a.GetName().FullName == assemblyName.FullName);

                if (loadedAssembly == null || references.Any(f => f.FullName == loadedAssembly.FullName))
                {
                    continue;
                }

                references.Add(loadedAssembly);
                GetReferences(loadedAssembly, references);
            }
        }
    }
}