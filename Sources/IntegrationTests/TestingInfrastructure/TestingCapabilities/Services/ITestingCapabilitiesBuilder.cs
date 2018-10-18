using System;
using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.TestingCapabilities.Models;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.TestingCapabilities.Services
{
    public interface ITestingCapabilitiesBuilder
    {
        TestingCapabilitiesContainer Build();

        ITestingCapabilitiesBuilder WithAutoMapper(Action<IMapperConfigurationExpression> config);
    }
}