using Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Models;

namespace Mmu.Mlh.ApplicationExtensions.Areas.EmailSending.Services
{
    public interface ISmtpSettingsProvider
    {
        SmtpSettings ProvideSmtpSettings();
    }
}