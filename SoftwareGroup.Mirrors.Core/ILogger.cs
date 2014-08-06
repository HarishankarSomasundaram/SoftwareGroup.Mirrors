using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareGroup.Mirrors.Core
{
    public interface ILogger
    {
        void LogDebug(object message);
        void LogError(Exception ex);
        void LogError(object message, Exception ex);
        void LogFatal(object message, Exception error);
        void LogInfo(object info);
    }
}
