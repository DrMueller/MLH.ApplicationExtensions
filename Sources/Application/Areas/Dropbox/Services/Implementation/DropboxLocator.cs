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
            var jsonPath = _fileSystem.Path.Combine(Environment.GetEnvironmentVariable("LocalAppData"), DropboxInfoPath);

            if (!_fileSystem.File.Exists(jsonPath))
            {
                jsonPath = _fileSystem.Path.Combine(Environment.GetEnvironmentVariable("AppData"), DropboxInfoPath);
            }

            if (!_fileSystem.File.Exists(jsonPath))
            {
                return Maybe.CreateNone<string>();
            }

            var dropboxPath = _fileSystem.File.ReadAllText(jsonPath).Split('\"')[5].Replace(@"\\", @"\");
            return dropboxPath;
        }
    }
}