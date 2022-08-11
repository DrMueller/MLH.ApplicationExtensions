using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models
{
    public class ImapSettings
    {
        public ImapSettings(string host, int port, string userName, string password)
        {
            Guard.StringNotNullOrEmpty(() => host);
            Guard.That(() => port > 0, "Port has to be larger than 0.");
            Guard.StringNotNullOrEmpty(() => userName);
            Guard.StringNotNullOrEmpty(() => password);

            Host = host;
            Port = port;
            UserName = userName;
            Password = password;
        }

        public string Host { get; }
        public string Password { get; }
        public int Port { get; }
        public string UserName { get; }
    }
}