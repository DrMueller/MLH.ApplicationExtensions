using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models
{
    public class Credentials
    {
        public Credentials(string userName, string password)
        {
            Guard.ObjectNotNull(() => userName);
            Guard.ObjectNotNull(() => password);

            UserName = userName;
            Password = password;
        }

        public string Password { get; }
        public string UserName { get; }
    }
}