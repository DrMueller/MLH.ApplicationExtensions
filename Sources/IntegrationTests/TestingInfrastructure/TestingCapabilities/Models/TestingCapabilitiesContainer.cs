using AutoMapper;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.TestingCapabilities.Models
{
    public class TestingCapabilitiesContainer
    {
        public TestingCapabilitiesContainer(IMapper mapper)
        {
            Mapper = mapper;
        }

        public IMapper Mapper { get; }
    }
}