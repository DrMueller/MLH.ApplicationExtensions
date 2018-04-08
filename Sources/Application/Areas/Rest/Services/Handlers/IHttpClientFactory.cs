using System.Net.Http;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Handlers
{
    public interface IHttpClientFactory
    {
        HttpClient CreateHttpClient();
    }
}