using System.Linq;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services.Servants;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingAreas.Areas.DependencyInjection.Handlers
{
    [TestFixture]
    public class AssemblyReferencesFetcherIntegrationTests
    {
        [Test]
        public void FetchingUnitTestAssemblyReferences_FetchesApplicationExtensionsReference()
        {
            // Arrange
            var testAssembly = typeof(AssemblyReferencesFetcherIntegrationTests).Assembly;
            var appExtensionsAssembly = typeof(AssemblyFetcher).Assembly;
            var assemblyParameters = new AssemblyParameters(testAssembly, "Mmu.Mlh");

            // Act
            var actualReferenceAssemblies = AssemblyFetcher.GetApplicationRelevantAssemblies(assemblyParameters);

            // Assert
            var actualAppExtensionsAssembly = actualReferenceAssemblies.FirstOrDefault(f => f == appExtensionsAssembly);

            Assert.That(actualAppExtensionsAssembly, Is.Not.Null);
        }

        [Test]
        public void FetchingUnitTestAssemblyReferences_HavingaReferencetoApplicationExtensions_FetchesIndirectAssemblies()
        {
            // Arrange
            var testAssembly = typeof(AssemblyReferencesFetcherIntegrationTests).Assembly;
            var languageExtensionsAssembly = typeof(Maybe<>).Assembly;
            var assemblyParameters = new AssemblyParameters(testAssembly, "Mmu.Mlh");

            // Act
            var actualReferenceAssemblies = AssemblyFetcher.GetApplicationRelevantAssemblies(assemblyParameters);

            // Assert
            var actualExtensionsAssembly = actualReferenceAssemblies.FirstOrDefault(f => f == languageExtensionsAssembly);

            Assert.That(actualExtensionsAssembly, Is.Not.Null);
        }
    }
}