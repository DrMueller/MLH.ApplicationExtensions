using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Models
{
    public class SmtpSettings
    {
        public string Host { get; }
        public string Password { get; }
        public int Port { get; }
        public string UserName { get; }

        public SmtpSettings(int port, string host, string userName, string password)
        {
            Guard.That(() => port > 0, "Port has to be larger than 0.");
            Guard.StringNotNullOrEmpty(() => host);
            Guard.StringNotNullOrEmpty(() => userName);
            Guard.StringNotNullOrEmpty(() => password);

            Port = port;
            Host = host;
            UserName = userName;
            Password = password;
        }
    }
}