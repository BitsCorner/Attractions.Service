using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsCorner.Logging
{
    public interface ILogger
    {
        void Log(string message, LogType logType);
        void Log(Exception exception);
    }

    public enum LogType
    {
        Verbose,
        Information,
        Warning,
        Error
    }
}
