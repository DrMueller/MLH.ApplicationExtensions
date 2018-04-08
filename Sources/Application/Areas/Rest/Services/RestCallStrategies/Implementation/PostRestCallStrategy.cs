using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Handlers;
using Newtonsoft.Json;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies.Implementation
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class PostRestCallStrategy : RestCallStrategyBase
    {
        public PostRestCallStrategy(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }

        public override RestCallMethodType MethodType { get; } = RestCallMethodType.Post;

        protected override async Task<HttpResponseMessage> PerformCallAsync(HttpClient httpClient, Uri requestUri, object requestBody)
        {
            var jsonBody = JsonConvert.SerializeObject(requestBody);
            var stringContent = new StringContent(jsonBody);
            return await httpClient.PostAsync(requestUri, stringContent);
        }
    }
}
