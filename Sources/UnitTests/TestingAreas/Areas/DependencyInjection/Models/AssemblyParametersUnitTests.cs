using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.UnitTests.TestingAreas.Areas.DependencyInjection.Models
{
    [TestFixture]
    public class AssemblyParametersUnitTests
    {
        [Test]
        public void CreatingFromAssembly_WithThreePrefixParts_TakesThreePrefixParts()
        {
            // Arrange
            var assembly = typeof(AssemblyParametersUnitTests).Assembly;

            // Act
            var actualAssemblyParameters = AssemblyParameters.CreateFromAssembly(assembly, 3);

            // Assert
            Assert.AreEqual(actualAssemblyParameters.AssemblyPrefix, "Mmu.Mlh.ApplicationExtensions");
        }

        [Test]
        public void CreatingAssemblyParameters_CreatesAssemblyParameters()
        {
            // Arrange
            const string TestPrefix = "TestPrefix";
            var assembly = typeof(AssemblyParametersUnitTests).Assembly;

            // Act
            var actualAssemblyParameters = new AssemblyParameters(assembly, TestPrefix);

            // Assert
            Assert.AreEqual(actualAssemblyParameters.RootAssembly, assembly);
            Assert.AreEqual(actualAssemblyParameters.AssemblyPrefix, TestPrefix);
        }
    }
}