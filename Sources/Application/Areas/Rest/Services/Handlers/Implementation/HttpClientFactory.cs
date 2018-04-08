using System.Net.Http;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Handlers.Implementation
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateHttpClient() => new HttpClient();
    }
}