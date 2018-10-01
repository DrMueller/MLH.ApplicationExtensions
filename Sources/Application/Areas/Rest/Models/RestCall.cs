using System;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Maybes;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models
{
    public class RestCall
    {
        public RestCall(Uri baseUri, string resourcePath, RestCallMethodType methodType, SecurityOptions securityOptions, Maybe<object> body)
        {
            Guard.ObjectNotNull(() => baseUri);
            Guard.StringNotNullOrEmpty(() => resourcePath);
            Guard.ObjectNotNull(() => securityOptions);
            Guard.ObjectNotNull(() => body);

            ResourcePath = resourcePath;
            MethodType = methodType;
            SecurityOptions = securityOptions;
            Body = body;
            BaseUri = baseUri;
        }

        public Uri BaseUri { get; }
        public Maybe<object> Body { get; }
        public RestCallMethodType MethodType { get; }
        public string ResourcePath { get; }
        public SecurityOptions SecurityOptions { get; }
    }
}