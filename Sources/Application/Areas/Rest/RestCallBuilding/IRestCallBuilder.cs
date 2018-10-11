﻿using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding
{
    public interface IRestCallBuilder
    {
        RestCall Build();

        IRestHeadersBuilder WithHeaders();

        IRestCallBuilder WithBody(object body);

        IRestCallBuilder WithouthResourcePath(string resourcePath);

        IRestCallBuilder WithSecurity(RestSecurity security);
    }
}