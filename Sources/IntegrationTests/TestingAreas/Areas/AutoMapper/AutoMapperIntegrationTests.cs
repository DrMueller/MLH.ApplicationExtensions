using System;
using System.Linq;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.Areas.Common.TestData.Services;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.Areas.Common.TestModels;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestCapabilities.Services;
using NUnit.Framework;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingAreas.Areas.AutoMapper
{
    [TestFixture]
    public class AutoMapperIntegrationTests
    {
        [Test]
        public void IgnoringUnmappedProperties_MapsOnlyDefinedProperties()
        {
            // Arrange
            var capabilities = TestingCapabilitiesBuilderFactory.CreateBuilder()
                .WithAutoMapper(
                    config =>
                    {
                        config.CreateMap<TestClass1, TestClass2>()
                            .ForMember(d => d.StringProperty1, c => c.MapFrom(f => f.StringProperty1))
                            .ForAllOtherMembers(f => f.Ignore());
                    })
                .Build();

            var testClass1 = TestModelFactory.CreateSome<TestClass1>(1).Single();

            // Act
            var actualMappedClass = capabilities.Mapper.Map<TestClass2>(testClass1);

            // Assert
            Assert.AreEqual(testClass1.StringProperty1, actualMappedClass.StringProperty1);
            Assert.That(actualMappedClass.StringProperty2, Is.Null.Or.Empty);
            Assert.That(actualMappedClass.StringProperty3, Is.Null.Or.Empty);
            Assert.AreEqual(actualMappedClass.DateTimeProperty, default(DateTime));
            Assert.AreEqual(actualMappedClass.EnumProperty1, default(TestEnum1));
        }
    }
}