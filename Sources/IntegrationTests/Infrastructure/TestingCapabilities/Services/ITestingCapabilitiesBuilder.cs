using System;
using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Models;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Services
{
    public interface ITestingCapabilitiesBuilder
    {
        TestingCapabilitiesContainer Build();

        ITestingCapabilitiesBuilder WithAutoMapper(Action<IMapperConfigurationExpression> config);
    }
}