using System;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services
{
    public interface ILoggingService
    {
        void LogException(Exception ex);

        void LogInfo(string message);

        void LogWarning(string message);
    }
}