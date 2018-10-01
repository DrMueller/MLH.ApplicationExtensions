using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;
using Newtonsoft.Json;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Services.Implementation
{
    [SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Justification = "Instantiated by StructureMap")]
    internal class RestProxy : IRestProxy
    {
        public async Task<T> PerformCallAsync<T>(RestCall restCall)
        {
            Guard.ObjectNotNull(() => restCall);

            var requestUri = new Uri(restCall.BaseUri, restCall.ResourcePath);

            using (var httpClient = new HttpClient())
            {
                var request = CreateRequest(requestUri, restCall.MethodType, restCall.Body, restCall.SecurityOptions);

                using (var response = await httpClient.SendAsync(request))
                {
                    var responseBody = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return ParseResultContent<T>(responseBody);
                    }

                    var exceptionMessage = $"Could not get data from {requestUri.AbsoluteUri}. Response: {responseBody}";
                    throw new Exception(exceptionMessage);
                }
            }
        }

        private static HttpRequestMessage CreateRequest(Uri requestUri, RestCallMethodType methodType, Maybe<object> body, SecurityOptions securityOptions)
        {
            var httpRequestMessage = new HttpRequestMessage(MapHttpMethod(methodType), requestUri);

            body.Evaluate(
                bodyObj =>
                {
                    var jsonBody = JsonConvert.SerializeObject(bodyObj);
                    httpRequestMessage.Content = new StringContent(jsonBody);

                    httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                });

            securityOptions.ApplySecurity(httpRequestMessage);
            return httpRequestMessage;
        }

        private static HttpMethod MapHttpMethod(RestCallMethodType methodType)
        {
            switch (methodType)
            {
                case RestCallMethodType.Get:
                    return HttpMethod.Get;
                case RestCallMethodType.Post:
                    return HttpMethod.Post;
                default:
                    throw new ArgumentException($"Invalid RestCallMethodType{ methodType }.");
            }
        }

        private static T ParseResultContent<T>(string content)
        {
            if (string.IsNullOrEmpty(content) || content == "[]")
            {
                return default(T);
            }

            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }
    }
}