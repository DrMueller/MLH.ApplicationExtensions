using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingAreas.Areas.DependencyInjection
{
    [TestFixture]
    public class ContainerInitializationServiceIntegrationTests
    {
        [Test]
        public void InitializingContainer_AddsConfigurationFromRegistry()
        {
            // Arrange
            var testAssembly = typeof(ContainerInitializationServiceIntegrationTests).Assembly;
            var assemblyParameters = new AssemblyParameters(testAssembly, "Mmu.Mlh");

            // Act
            var actualContainer = ContainerInitializationService.CreateInitializedContainer(assemblyParameters);

            // Assert
            var provisioningService = actualContainer.GetInstance<IProvisioningService>();
            Assert.IsNotNull(provisioningService);
        }

        [Test]
        public void InitializingContainer_CreatesContainer()
        {
            // Arrange
            var testAssembly = typeof(ContainerInitializationServiceIntegrationTests).Assembly;
            var assemblyParameters = new AssemblyParameters(testAssembly, "Mmu.Mlh");

            // Act
            var actualContainer = ContainerInitializationService.CreateInitializedContainer(assemblyParameters);

            // Assert
            Assert.That(actualContainer, Is.Not.Null);
        }
    }
}