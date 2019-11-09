using System.Threading.Tasks;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailReceiving.Imap.Services.Servants
{
    internal interface IImapClientProxyFactory
    {
        Task<IImapClientProxy> CreateAuthenticatedProxyAsync();
    }
}