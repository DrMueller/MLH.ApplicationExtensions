using System.Net.Http;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security.SecurityTypes
{
    public class Anonymous : SecurityOptions
    {
        internal override void ApplySecurity(HttpRequestMessage requestMessage)
        {
            // No security, nothing to do
        }
    }
}