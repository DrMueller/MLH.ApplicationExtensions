using System;
using JetBrains.Annotations;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.Areas.Common.TestData.Models
{
    [UsedImplicitly]
    public class TestClass1
    {
        public DateTime DateTimeProperty { get; set; }
        public TestEnum1 EnumProperty1 { get; set; }
        
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string StringProperty1 { get; set; }
        public string StringProperty2 { get; set; }
        public string StringProperty3 { get; set; }
    }
}