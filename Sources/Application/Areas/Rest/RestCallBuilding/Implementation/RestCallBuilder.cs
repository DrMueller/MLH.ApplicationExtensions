using System;
using System.Collections.Generic;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding.Implementation
{
    internal class RestCallBuilder : IRestCallBuilder
    {
        private readonly Uri _basePath;
        private readonly List<RestHeader> _headers = new List<RestHeader>();
        private readonly RestCallMethodType _methodType;
        private Maybe<object> _body = Maybe.CreateNone<object>();
        private Maybe<string> _resourcePath = Maybe.CreateNone<string>();
        private RestSecurity _restSecurity = RestSecurity.CreateAnonymous();

        public RestCallBuilder(Uri basePath, RestCallMethodType methodType)
        {
            _basePath = basePath;
            _methodType = methodType;
        }

        public RestCall Build()
        {
            return new RestCall(
                _basePath,
                _resourcePath,
                _methodType,
                _restSecurity,
                new RestHeaders(_headers),
                _body);
        }

        public IRestCallBuilder WithBody(object body)
        {
            _body = body;
            return this;
        }

        public IRestHeadersBuilder WithHeaders()
        {
            return new RestHeadersBuilder(this, _headers);
        }

        public IRestCallBuilder WithouthResourcePath(string resourcePath)
        {
            _resourcePath = resourcePath;
            return this;
        }

        public IRestCallBuilder WithSecurity(RestSecurity security)
        {
            _restSecurity = security;
            return this;
        }
    }
}