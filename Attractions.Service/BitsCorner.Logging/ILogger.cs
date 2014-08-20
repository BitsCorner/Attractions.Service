using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsCorner.Logging
{
    public interface ILogger
    {
        Task Log(string message, LogType logType);
        Task Log(Exception exception);
    }

    public enum LogType
    {
        Verbose,
        Information,
        Warning,
        Error
    }
}
