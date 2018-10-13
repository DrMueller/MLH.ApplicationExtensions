using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Newtonsoft.Json;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies.Servants.Implementation
{
    internal class HttpRequestFactory : IHttpRequestFactory
    {
        public HttpRequestMessage Create(RestCall restCall)
        {
            var requestUri = new Uri(restCall.BaseUri, restCall.ResourcePath);
            var httpRequestMessage = new HttpRequestMessage(MapHttpMethod(restCall.MethodType), requestUri);

            CheckAddBody(httpRequestMessage, restCall.Body);
            restCall.Headers.Entries.ForEach(header => httpRequestMessage.Headers.Add(header.Name, header.Value));
            restCall.Security.ApplySecurity(httpRequestMessage);

            return httpRequestMessage;
        }

        private static void CheckAddBody(HttpRequestMessage httpRequestMessage, Maybe<RestCallBody> body)
        {
            body.Evaluate(
                bodyObj =>
                {
                    var jsonBody = JsonConvert.SerializeObject(bodyObj.Payload);
                    httpRequestMessage.Content = new StringContent(jsonBody);
                    httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(bodyObj.MediaType);
                });
        }

        private static HttpMethod MapHttpMethod(RestCallMethodType methodType)
        {
            switch (methodType)
            {
                case RestCallMethodType.Get:
                    return HttpMethod.Get;
                case RestCallMethodType.Post:
                    return HttpMethod.Post;
                case RestCallMethodType.Patch:
                    return new HttpMethod("PATCH");
                default:
                    throw new ArgumentException($"Invalid RestCallMethodType{methodType}.");
            }
        }
    }
}