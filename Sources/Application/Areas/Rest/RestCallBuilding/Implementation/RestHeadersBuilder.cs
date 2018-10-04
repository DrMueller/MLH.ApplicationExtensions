using System.Collections.Generic;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding.NewFolder
{
    internal class RestHeadersBuilder : IRestHeadersBuilder
    {
        private readonly List<RestHeader> _headers;
        private readonly RestCallBuilder _restCallBuilder;

        public RestHeadersBuilder(RestCallBuilder restCallBuilder, List<RestHeader> headers)
        {
            _restCallBuilder = restCallBuilder;
            _headers = headers;
        }

        public IRestHeadersBuilder AddHeader(string name, string value)
        {
            _headers.Add(new RestHeader(name, value));
            return this;
        }

        public IRestCallBuilder BuildHeaders()
        {
            return _restCallBuilder;
        }
    }
}