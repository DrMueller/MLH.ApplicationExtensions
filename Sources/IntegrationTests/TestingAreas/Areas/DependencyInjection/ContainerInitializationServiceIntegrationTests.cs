using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingAreas.Areas.DependencyInjection
{
    [TestFixture]
    public class ContainerInitializationServiceIntegrationTests
    {
        [Test]
        public void InitializingContainer_AddsConfigurationFromRegistryegistry()
        {
            // Arrange
            var testAssembly = typeof(ContainerInitializationServiceIntegrationTests).Assembly;

            // Act
            var actualContainer = ContainerInitializationService.CreateInitializedContainer(testAssembly);

            // Assert
            var restStrategies = actualContainer.GetAllInstances<IRestCallStrategy>();
            CollectionAssert.IsNotEmpty(restStrategies);
        }

        [Test]
        public void InitializingContainer_CreatesContainer()
        {
            // Arrange
            var testAssembly = typeof(ContainerInitializationServiceIntegrationTests).Assembly;

            // Act
            var actualContainer = ContainerInitializationService.CreateInitializedContainer(testAssembly);

            // Assert
            Assert.That(actualContainer, Is.Not.Null);
        }

        [Test]
        public void InitializingContainer_CreatesValidContainer()
        {
            // Arrange
            var testAssembly = typeof(ContainerInitializationServiceIntegrationTests).Assembly;

            // Act
            var actualContainer = ContainerInitializationService.CreateInitializedContainer(testAssembly);

            // Assert
            Assert.That(actualContainer, Is.Not.Null);
            Assert.That(() => actualContainer.AssertConfigurationIsValid(), Throws.Nothing);
        }
    }
}