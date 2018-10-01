using System.Net.Http;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security.SecurityTypes;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security
{
    public abstract class SecurityOptions
    {
        internal abstract void ApplySecurity(HttpRequestMessage requestMessage);

        public static SecurityOptions CreateAnonymous()
        {
            return new Anonymous();
        }

        public static SecurityOptions CreateBasicAuthentication(string userName, string password)
        {
            return new BasicAuthUserNamePassword(userName, password);
        }

        public static SecurityOptions CreateTokenSecurity(string encodedToken)
        {
            return new TokenSecurity(encodedToken);
        }
    }
}