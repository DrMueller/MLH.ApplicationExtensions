using System;
using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
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
            var assemblyParameters = new AssemblyParameters(typeof(TestingCapabilitiesBuilder).Assembly, "Mmu");

            _configExpressionMaybe = Maybe.CreateNone<Action<IMapperConfigurationExpression>>();
            _container = ContainerInitializationService.CreateInitializedContainer(assemblyParameters);
        }

        public TestingCapabilitiesContainer Build()
        {
            var provisioningService = _container.GetInstance<IProvisioningService>();
            var mapper = EvaluateMapper();

            return new TestingCapabilitiesContainer(mapper, provisioningService);
        }

        public ITestingCapabilitiesBuilder WithAutoMapper(Action<IMapperConfigurationExpression> config)
        {
            _configExpressionMaybe = Maybe.CreateSome(config);
            return this;
        }

        public static ITestingCapabilitiesBuilder Start() => new TestingCapabilitiesBuilder();

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