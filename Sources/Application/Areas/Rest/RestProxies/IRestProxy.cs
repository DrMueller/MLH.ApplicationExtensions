using System;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies
{
    public interface IRestProxy
    {
        Task<T> PerformCallAsync<T>(RestCall restCall);

        Task<T> PerformCallAsync<T>(Func<IRestCallBuilderFactory, RestCall> restCallBuilderCallback);
    }
}