using Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Services.Implementation;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Services
{
    public static class TestingCapabilitiesBuilderFactory
    {
        public static ITestingCapabilitiesBuilder CreateBuilder() => new TestingCapabilitiesBuilder();
    }
}