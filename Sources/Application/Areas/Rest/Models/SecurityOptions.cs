namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models
{
    public class SecurityOptions
    {
        private SecurityOptions(bool applySecurity, Credentials credentials)
        {
            ApplySecurity = applySecurity;
            Credentials = credentials;
        }

        public bool ApplySecurity { get; }
        public Credentials Credentials { get; }

        public static SecurityOptions CreateAnonymous() => new SecurityOptions(false, null);

        public static SecurityOptions CreateBasicAuthentication(string userName, string password) => new SecurityOptions(true, new Credentials(userName, password));
    }
}