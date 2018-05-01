using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Models
{
    public class TestingCapabilitiesContainer
    {
        public TestingCapabilitiesContainer(IMapper mapper, IProvisioningService provisioningService)
        {
            Mapper = mapper;
            ProvisioningService = provisioningService;
        }

        public IMapper Mapper { get; }
        public IProvisioningService ProvisioningService { get; }
    }
}