using System;
using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.TestingCapabilities.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;
using StructureMap;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.TestingCapabilities.Services.Implementation
{
    public class TestingCapabilitiesBuilder : ITestingCapabilitiesBuilder
    {
        private readonly IContainer _container;
        private Maybe<Action<IMapperConfigurationExpression>> _configExpressionMaybe;

        public TestingCapabilitiesBuilder()
        {
            var containerConfig = new ContainerConfiguration(typeof(TestingCapabilitiesBuilder).Assembly, "Mmu");

            _configExpressionMaybe = Maybe.CreateNone<Action<IMapperConfigurationExpression>>();
            _container = ContainerInitializationService.CreateInitializedContainer(containerConfig);
        }

        public static ITestingCapabilitiesBuilder Start()
        {
            return new TestingCapabilitiesBuilder();
        }

        public TestingCapabilitiesContainer Build()
        {
            var serviceLocator = _container.GetInstance<IServiceLocator>();
            var mapper = EvaluateMapper();

            return new TestingCapabilitiesContainer(mapper, serviceLocator);
        }

        public ITestingCapabilitiesBuilder WithAutoMapper(Action<IMapperConfigurationExpression> config)
        {
            _configExpressionMaybe = Maybe.CreateSome(config);
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