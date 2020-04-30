using System;
using System.Threading.Tasks;
using Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace Mmu.Mlh.ApplicationExtensions.TestConsole.Areas.ConsoleCommands
{
    public class LocateDropbox : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IDropboxLocator _dropboxLocator;
        public string Description => "Locate Dropbox";
        public ConsoleKey Key => ConsoleKey.F3;

        public LocateDropbox(IDropboxLocator dropboxLocator, IConsoleWriter consoleWriter)
        {
            _dropboxLocator = dropboxLocator;
            _consoleWriter = consoleWriter;
        }

        public Task ExecuteAsync()
        {
            var dropboxPathMybe = _dropboxLocator.LocateDropboxPath();
            var dropboxPath = dropboxPathMybe.Reduce(() => "(Not found)");
            _consoleWriter.WriteLine($"Dropbox path: {dropboxPath}");

            return Task.CompletedTask;
        }
    }
}