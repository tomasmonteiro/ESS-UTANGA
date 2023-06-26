using NLog;
using SistemaDeGestaoEscolar.Common;

namespace SistemaDeGestaoEscolar.WebApp
{
    public sealed class LogConcrete : ILog
    {
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public LogConcrete()
        {
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }
    }
}