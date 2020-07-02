using System;
using System.IO.Abstractions;
using Mmu.Mlh.LanguageExtensions.Areas.Types.FunctionsResults;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services.Implementation
{
    internal class DropboxLocator : IDropboxLocator
    {
        private const string DropboxInfoPath = @"Dropbox\info.json";

        private readonly IFileSystem _fileSystem;

        public DropboxLocator(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public Maybe<string> LocateDropboxPath()
        {
            var appDataPathResult = TryGettingAppDataPath();

            if (appDataPathResult.IsSuccess)
            {
                var dropboxPath = _fileSystem.File.ReadAllText(appDataPathResult.Value).Split('\"')[5].Replace(@"\\", @"\");

                return dropboxPath;
            }

            // Fallback, check if system variable is set
            var dropboxPathViaSystemVariable = GetDropboxPathViaSystemVariable();

            if (string.IsNullOrEmpty(dropboxPathViaSystemVariable))
            {
                return Maybe.CreateNone<string>();
            }

            return dropboxPathViaSystemVariable;
        }

        private static string GetDropboxPathViaSystemVariable()
        {
            return Environment.GetEnvironmentVariable("DropboxPath", EnvironmentVariableTarget.Machine);
        }

        private FunctionResult<string> TryCreatingDropboxPath(string environmentVariableName)
        {
            var envValue = Environment.GetEnvironmentVariable(environmentVariableName);
            var dropboxInfoFullPath = _fileSystem.Path.Combine(envValue, DropboxInfoPath);

            if (_fileSystem.File.Exists(dropboxInfoFullPath))
            {
                return FunctionResult.CreateSuccess(dropboxInfoFullPath);
            }

            return FunctionResult.CreateFailure<string>();
        }

        private FunctionResult<string> TryGettingAppDataPath()
        {
            var checkResult = TryCreatingDropboxPath("LocalAppData");

            if (!checkResult.IsSuccess)
            {
                checkResult = TryCreatingDropboxPath("AppData");
            }

            return checkResult;
        }
    }
}