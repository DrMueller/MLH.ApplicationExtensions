using System;
using System.Collections.Generic;
using System.Text;

namespace Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning
{
    public interface IProvisioningService
    {
        IReadOnlyCollection<T> GetAllServices<T>();

        T GetService<T>();

        object GetService(Type pluginType);
    }
}
