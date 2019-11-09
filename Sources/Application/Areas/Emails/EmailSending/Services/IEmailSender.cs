using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Email email);
    }
}