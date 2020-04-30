using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services
{
    public interface IDropboxLocator
    {
        Maybe<string> LocateDropboxPath();
    }
}