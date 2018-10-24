﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services.Servants
{
    internal static class AssemblyFetcher
    {
        internal static IReadOnlyCollection<Assembly> GetApplicationRelevantAssemblies(AssemblyParameters assemblyParameters)
        {
            var assemblies = new List<Assembly>();

            // Search Assemblies not in the root Path, but referenced, f.e. NuGet Packages
            AppendAssembliesByAssemblyReferences(
                assemblyParameters.RootAssembly,
                assemblyParameters.AssemblyPrefix,
                assemblies);

            // Search Assemblies in the roto Path
            AppendAssembliesInBaseDirectory(
                assemblyParameters.RootAssembly,
                assemblyParameters.AssemblyPrefix,
                assemblies);

            assemblies = assemblies.Distinct().ToList();
            return assemblies;
        }

        private static void AppendAssembliesByAssemblyReferences(Assembly assembly, string assemblyPrefix, ICollection<Assembly> assemblies)
        {
            foreach (var assemblyName in assembly.GetReferencedAssemblies())
            {
                Debug.WriteLine(assemblyName);
                var loadedAssembly = Assembly.Load(assemblyName);
                if (!IsRelevantForApplication(loadedAssembly, assemblyPrefix))
                {
                    continue;
                }

                assemblies.Add(loadedAssembly);
                AppendAssembliesByAssemblyReferences(loadedAssembly, assemblyPrefix, assemblies);
            }
        }

        private static void AppendAssembliesInBaseDirectory(Assembly rootAssembly, string assemblyPrefix, List<Assembly> assemblies)
        {
            var assemblyExtensions = new[]
            {
                ".EXE",
                ".DLL"
            };

            var codeDirectory = Path.GetDirectoryName(rootAssembly.Location);
            var assemblyFileInfos = Directory.GetFiles(codeDirectory)
                .Select(f => new FileInfo(f))
                .Where(f => assemblyExtensions.Contains(f.Extension.ToUpperInvariant()));

            var loadedAssemblies = new List<Assembly>();

            foreach (var fi in assemblyFileInfos)
            {
                try
                {
                    loadedAssemblies.Add(Assembly.LoadFrom(fi.FullName));
                }
                catch (Exception)
                {
                    // Best effort, do nothing here
                }
            }

            var relevantAssemblies = loadedAssemblies
                .Where(f => IsRelevantForApplication(f, assemblyPrefix))
                .ToList();

            assemblies.AddRange(relevantAssemblies);
        }

        private static bool IsRelevantForApplication(Assembly assembly, string assemblyPrefix)
        {
            var relevantPrefixes = new[]
            {
                assemblyPrefix,
                "Mmu"
            };

            return assembly != null && relevantPrefixes.Any(relevantPrefix => assembly.FullName.StartsWith(relevantPrefix, StringComparison.OrdinalIgnoreCase));
        }
    }
}