using System;
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
                var referencedAssembly = AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .SingleOrDefault(a => a.GetName().FullName == assemblyName.FullName);

                if (referencedAssembly == null || references.Any(f => f.FullName == referencedAssembly.FullName))
                {
                    continue;
                }

                GetReferences(referencedAssembly, references);
                references.Add(referencedAssembly);
            }
        }
    }
}