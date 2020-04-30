using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Email email);
    }
}