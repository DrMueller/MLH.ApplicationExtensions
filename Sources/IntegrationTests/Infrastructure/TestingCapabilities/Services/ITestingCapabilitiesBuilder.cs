using System;
using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Models;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Services
{
    public interface ITestingCapabilitiesBuilder
    {
        ITestingCapabilitiesBuilder WithAutoMapper(Action<IMapperConfigurationExpression> config);

        TestingCapabilitiesContainer Build();
    }
}