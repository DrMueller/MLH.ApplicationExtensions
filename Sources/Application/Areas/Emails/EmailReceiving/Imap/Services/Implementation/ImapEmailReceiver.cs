using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MimeKit;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants.Implementation;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Implementation
{
    internal class ImapEmailReceiver : IImapEmailReceiver
    {
        private readonly ImapClientProxyFactory _clientFactory;

        public ImapEmailReceiver(ImapClientProxyFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IReadOnlyCollection<Email>> ReceiveFromInboxAsync()
        {
            using (var clientProxy = await _clientFactory.CreateAuthenticatedProxyAsync())
            {
                var inbox = clientProxy.Inbox;
                await inbox.OpenAsync(FolderAccess.ReadOnly);

                var emailTasks = new List<Task<Email>>();

                for (var i = 0; i < inbox.Count; i++)
                {
                    emailTasks.Add(MapFromNativeMessageAsync(await inbox.GetMessageAsync(i)));
                }

                var emails = await Task.WhenAll(emailTasks.ToArray());
                await clientProxy.DisconnectAsync();
                return emails.ToList();
            }
        }

        private static async Task<Email> MapFromNativeMessageAsync(MimeMessage mimeMessage)
        {
            using (var stream = new MemoryStream())
            {
                await mimeMessage.Body.WriteToAsync(FormatOptions.Default, stream);
                stream.Position = 0;
                using (var sr = new StreamReader(stream))
                {
                    var body = await sr.ReadToEndAsync();
                    var fromAddresses = mimeMessage.From.Mailboxes.Select(mb => mb.Address).ToList();
                    var email = new Email(fromAddresses, mimeMessage.Subject, body);
                    return email;
                }
            }
        }
    }
}