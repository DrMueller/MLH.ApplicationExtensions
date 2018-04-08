using System;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services.Handlers
{
    public interface ILoggerProxy
    {
        void LogError(Exception ex, string message);

        void LogInformation(string message);

        void LogWarning(string message);
    }
}