namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestCallBuilding
{
    public interface IRestHeadersBuilder
    {
        IRestHeadersBuilder AddHeader(string name, string value);

        IRestCallBuilder BuildHeaders();
    }
}