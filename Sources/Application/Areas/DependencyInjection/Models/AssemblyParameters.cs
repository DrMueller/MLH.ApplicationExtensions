using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models
{
    public class AssemblyParameters
    {
        public AssemblyParameters(Assembly rootAssembly, string assemblyPrefix)
        {
            Guard.ObjectNotNull(() => assemblyPrefix);
            Guard.ObjectNotNull(() => rootAssembly);

            RootAssembly = rootAssembly;
            AssemblyPrefix = assemblyPrefix;
        }

        public string AssemblyPrefix { get; }
        public Assembly RootAssembly { get; }
    }
}