using log4net;
using SoftwareGroup.Mirrors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Infra
{
    public class Log4NetLogger : ILogger
    {
        private static Lazy<ILog> _logger = new Lazy<ILog>(() =>
        {
            var lgr = LogManager.GetLogger("");
            log4net.Config.XmlConfigurator.Configure();
            return lgr;
        });


        /// <summary>
        /// Property to access lazy initialized logger instance.
        /// </summary>
        private static ILog logger
        {
            get { return _logger.Value; }
        }

        /// <summary>
        /// Writes the given exception as error to log
        /// </summary>
        /// <param name="ex"></param>
        public void LogError(Exception ex)
        {
            logger.Error(ex);
        }

        /// <summary>
        /// Writes the given message along with the exception to log.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public void LogError(object message, Exception ex)
        {
            logger.Error(message, ex);
        }

        /// <summary>
        /// Writes the given debug message to log
        /// </summary>
        /// <param name="message"></param>
        public void LogDebug(object message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Writes the given info message to log
        /// </summary>
        /// <param name="info"></param>
        public void LogInfo(object info)
        {
            logger.Info(info);
        }

        /// <summary>
        /// Writes the given fatal message to log.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="error"></param>
        public void LogFatal(object message, Exception error)
        {
            if (error == null)
                logger.Fatal(message);
            else
                logger.Fatal(message, error);
        }
    }
}
