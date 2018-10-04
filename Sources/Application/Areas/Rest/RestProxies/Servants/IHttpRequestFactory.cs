using System.Net.Http;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies.Servants
{
    internal interface IHttpRequestFactory
    {
        HttpRequestMessage Create(RestCall restCall);
    }
}