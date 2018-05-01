using Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestCapabilities.Services.Implementation;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestCapabilities.Services
{
    public static class TestingCapabilitiesBuilderFactory
    {
        public static ITestingCapabilitiesBuilder CreateBuilder() => new TestingCapabilitiesBuilder();
    }
}