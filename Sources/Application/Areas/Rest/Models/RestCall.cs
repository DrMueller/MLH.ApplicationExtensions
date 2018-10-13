using System;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models
{
    public class RestCall
    {
        public Uri BaseUri { get; }
        public Maybe<RestCallBody> Body { get; }
        public RestHeaders Headers { get; }
        public RestCallMethodType MethodType { get; }
        public Maybe<string> ResourcePath { get; }
        public RestSecurity Security { get; }

        internal RestCall(Uri baseUri, Maybe<string> resourcePath, RestCallMethodType methodType, RestSecurity security, RestHeaders headers, Maybe<RestCallBody> body)
        {
            Guard.ObjectNotNull(() => baseUri);
            Guard.ObjectNotNull(() => security);
            Guard.ObjectNotNull(() => headers);
            Guard.ObjectNotNull(() => body);

            ResourcePath = resourcePath;
            MethodType = methodType;
            Security = security;
            Headers = headers;
            Body = body;
            BaseUri = baseUri;
        }
    }
}