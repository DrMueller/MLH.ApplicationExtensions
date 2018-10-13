using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding
{
    public interface IRestCallBuilder
    {
        RestCall Build();

        IRestCallBuilder WithBody(RestCallBody body);

        IRestHeadersBuilder WithHeaders();

        IRestCallBuilder WithResourcePath(string resourcePath);

        IRestCallBuilder WithSecurity(RestSecurity security);
    }
}