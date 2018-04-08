using System;
using Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services.Implementation;
using NLog;

namespace Mmu.Mlh.ApplicationExtensions.Areas.Logging.Services.Handlers.Implementation
{
    public class LoggerProxy : ILoggerProxy
    {
        private static readonly ILogger _logger = LogManager.GetLogger(nameof(LoggingService));

        public void LogError(Exception ex, string message)
        {
            _logger.Error(ex, message);
        }

        public void LogInformation(string message)
        {
            _logger.Info(message);
        }

        public void LogWarning(string message)
        {
            _logger.Warn(message);
        }
    }
}