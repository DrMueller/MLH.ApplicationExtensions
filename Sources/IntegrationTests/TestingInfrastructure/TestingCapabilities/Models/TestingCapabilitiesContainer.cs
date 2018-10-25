using AutoMapper;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.TestingCapabilities.Models
{
    public class TestingCapabilitiesContainer
    {
        public IMapper Mapper { get; }
        public IServiceLocator ServiceLocator { get; }

        public TestingCapabilitiesContainer(IMapper mapper, IServiceLocator serviceLocator)
        {
            Mapper = mapper;
            ServiceLocator = serviceLocator;
        }
    }
}