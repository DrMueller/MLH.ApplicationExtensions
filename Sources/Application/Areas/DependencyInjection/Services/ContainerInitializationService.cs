using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services.Servants;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using StructureMap;

namespace Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services
{
    public static class ContainerInitializationService
    {
        public static Container CreateInitializedContainer(AssemblyParameters assemblyParameters)
        {
            var result = new Container();
            var assemblies = AssemblyFetcher.GetApplicationRelevantAssemblies(assemblyParameters);

            result.Configure(
                config =>
                {
                    config.Scan(
                        scanner =>
                        {
                            foreach (var assembly in assemblies)
                            {
                                scanner.Assembly(assembly);
                            }

                            scanner.LookForRegistries();
                        });

                    AddAutoMapper(config, assemblies);
                });

            var provisioningService = result.GetInstance<IProvisioningService>();
            ProvisioningServiceSingleton.Initialize(provisioningService);
            return result;
        }

        private static void AddAutoMapper(IProfileRegistry config, IEnumerable<Assembly> assemblies)
        {
            var profileTypes = assemblies.SelectMany(f => f.GetTypes().Where(t => typeof(Profile).IsAssignableFrom(t))).ToList();

            var mapperConfiguration = new MapperConfiguration(
                cfg =>
                {
                    foreach (var profileType in profileTypes)
                    {
                        cfg.AddProfile(profileType);
                    }
                });

            var mapper = mapperConfiguration.CreateMapper();
            config.For<IMapper>().Use(mapper);
        }
    }
}