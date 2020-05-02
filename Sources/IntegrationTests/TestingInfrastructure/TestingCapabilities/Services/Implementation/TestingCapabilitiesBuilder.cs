using System;
using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.TestingCapabilities.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.ApplicationExtensions.IntegrationTests.TestingInfrastructure.TestingCapabilities.Services.Implementation
{
    public class TestingCapabilitiesBuilder : ITestingCapabilitiesBuilder
    {
        private Maybe<Action<IMapperConfigurationExpression>> _configExpressionMaybe;

        public TestingCapabilitiesBuilder()
        {
            _configExpressionMaybe = Maybe.CreateNone<Action<IMapperConfigurationExpression>>();
        }

        public static ITestingCapabilitiesBuilder Start()
        {
            return new TestingCapabilitiesBuilder();
        }

        public TestingCapabilitiesContainer Build()
        {
            var mapper = EvaluateMapper();

            return new TestingCapabilitiesContainer(mapper);
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