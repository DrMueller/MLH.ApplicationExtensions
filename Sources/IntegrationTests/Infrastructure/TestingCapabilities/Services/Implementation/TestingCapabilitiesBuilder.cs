using System;
using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using StructureMap;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.Infrastructure.TestingCapabilities.Services.Implementation
{
    public class TestingCapabilitiesBuilder : ITestingCapabilitiesBuilder
    {
        private readonly IContainer _container;
        private Maybe<Action<IMapperConfigurationExpression>> _configExpressionMaybe;

        public TestingCapabilitiesBuilder()
        {
            _configExpressionMaybe = Maybe<Action<IMapperConfigurationExpression>>.CreateNone();
            _container = ContainerInitializationService.CreateInitializedContainer(typeof(TestingCapabilitiesBuilder).Assembly);
        }

        public TestingCapabilitiesContainer Build()
        {
            var provisioningService = _container.GetInstance<IProvisioningService>();
            var mapper = EvaluateMapper();

            return new TestingCapabilitiesContainer(mapper, provisioningService);
        }

        public ITestingCapabilitiesBuilder WithAutoMapper(Action<IMapperConfigurationExpression> config)
        {
            _configExpressionMaybe = Maybe<Action<IMapperConfigurationExpression>>.CreateSome(config);
            return this;
        }

        private IMapper EvaluateMapper()
        {
            return _configExpressionMaybe.Evaluate(
                configExpression =>
                {
                    var mapper = new MapperConfiguration(configExpression).CreateMapper();
                    return mapper;
                },
                () => null);
        }
    }
}