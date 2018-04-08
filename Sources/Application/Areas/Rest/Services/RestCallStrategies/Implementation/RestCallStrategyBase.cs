using System;
using System.Net.Http;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Handlers;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.RestCallStrategies.Implementation
{
    internal abstract class RestCallStrategyBase : IRestCallStrategy
    {
        private readonly IHttpClientFactory _httpClientFactory;

        protected RestCallStrategyBase(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public abstract RestCallMethodType MethodType { get; }

        public async Task<string> SendRequestAsync(Uri requestUri, object requestBody)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                using (var response = await PerformCallAsync(httpClient, requestUri, requestBody))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        return responseBody;
                    }

                    var exceptionMessage = $"Could not get data from {requestUri.AbsoluteUri}. Response: {responseBody}";
                    throw new Exception(exceptionMessage);
                }
            }
        }

        protected abstract Task<HttpResponseMessage> PerformCallAsync(HttpClient httpClient, Uri requestUri, object requestBody);
    }
}