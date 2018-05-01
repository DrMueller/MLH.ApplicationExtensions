using System;
using AutoMapper;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestCapabilities.Services
{
    public interface ITestingCapabilitiesBuilder
    {
        ITestingCapabilitiesBuilder WithAutoMapper(Action<IMapperConfigurationExpression> config);

        TestingCapabilitiesContainer Build();
    }
}