using Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Emails.EmailSending.Services
{
    public interface ISmtpSettingsProvider
    {
        SmtpSettings ProvideSmtpSettings();
    }
}