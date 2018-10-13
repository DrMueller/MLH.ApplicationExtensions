using System.Linq;
using System.Reflection;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models
{
    public class AssemblyParameters
    {
        public string AssemblyPrefix { get; }
        public Assembly RootAssembly { get; }

        public AssemblyParameters(Assembly rootAssembly, string assemblyPrefix)
        {
            Guard.ObjectNotNull(() => assemblyPrefix);
            Guard.ObjectNotNull(() => rootAssembly);

            RootAssembly = rootAssembly;
            AssemblyPrefix = assemblyPrefix;
        }

        public static AssemblyParameters CreateFromAssembly(Assembly assembly, int namespaceParts = 2)
        {
            var prefixParts = assembly.FullName.Split('.')
                .Take(namespaceParts);

            var assemblyPrefix = string.Join(".", prefixParts);

            var result = new AssemblyParameters(assembly, assemblyPrefix);
            return result;
        }
    }
}