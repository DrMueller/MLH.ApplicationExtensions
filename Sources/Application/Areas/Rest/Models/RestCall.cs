using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models
{
    public class RestCall
    {
        public RestCall(Uri baseUri, string resourcePath, RestCallMethodType methodType, object body = null)
        {
            Guard.ObjectNotNull(() => baseUri);
            Guard.StringNotNullOrEmpty(() => resourcePath);

            ResourcePath = resourcePath;
            MethodType = methodType;
            BaseUri = baseUri;
            Body = body;
        }

        public Uri BaseUri { get; }
        public object Body { get; }
        public RestCallMethodType MethodType { get; }
        public string ResourcePath { get; }
    }
}