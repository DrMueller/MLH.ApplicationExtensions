using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using StructureMap;

namespace Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning.Implementation
{
    public class ProvisioningService : IProvisioningService
    {
        private readonly IContainer _container;

        public ProvisioningService(IContainer container)
        {
            _container = container;
        }

        public IReadOnlyCollection<T> GetAllServices<T>()
        {
            var result = _container.GetAllInstances<T>().ToList();
            return result;
        }

        public T GetService<T>()
        {
            var result = _container.GetInstance<T>();
            return result;
        }

        public object GetService(Type pluginType)
        {
            var result = _container.GetInstance(pluginType);
            return result;
        }
    }
}