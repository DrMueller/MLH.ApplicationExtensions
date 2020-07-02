using System;
using System.IO.Abstractions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services.Implementation
{
    internal class DropboxLocator : IDropboxLocator
    {
        private readonly IFileSystem _fileSystem;

        public DropboxLocator(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public Maybe<string> LocateDropboxPath()
        {
            const string DropboxInfoPath = @"Dropbox\info.json";
            var appDataPath = GetAppDataPath();

            if (string.IsNullOrEmpty(appDataPath))
            {
                var dropboxPathViaSystemVariable = GetDropboxPathViaSystemVariable();
                if (string.IsNullOrEmpty(dropboxPathViaSystemVariable))
                {
                    return Maybe.CreateNone<string>();
                }

                return dropboxPathViaSystemVariable;
            }

            var dropboxInfoFullPath = _fileSystem.Path.Combine(appDataPath, DropboxInfoPath);
            var dropboxPath = _fileSystem.File.ReadAllText(dropboxInfoFullPath).Split('\"')[5].Replace(@"\\", @"\");
            return dropboxPath;
        }

        private static string GetAppDataPath()
        {
            var localAppDataPath = Environment.GetEnvironmentVariable("LocalAppData");
            return string.IsNullOrEmpty(localAppDataPath) ? Environment.GetEnvironmentVariable("AppData") : localAppDataPath;
        }

        private static string GetDropboxPathViaSystemVariable()
        {
            return Environment.GetEnvironmentVariable("DropboxPath", EnvironmentVariableTarget.Machine);
        }
    }
}