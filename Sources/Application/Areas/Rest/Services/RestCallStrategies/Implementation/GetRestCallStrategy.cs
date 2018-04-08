using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Handlers;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies.Implementation
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class GetRestCallStrategy : RestCallStrategyBase
    {
        public GetRestCallStrategy(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override RestCallMethodType MethodType { get; } = RestCallMethodType.Get;

        protected override async Task<HttpResponseMessage> PerformCallAsync(HttpClient httpClient, Uri requestUri, object requestBody) => await httpClient.GetAsync(requestUri);
    }
}