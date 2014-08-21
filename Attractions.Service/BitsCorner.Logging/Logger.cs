using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsCorner.Logging
{
    public class Logger : ILogger
    {
        private LogWriter defaultWriter; 
        public Logger()
        {
            LoggingConfiguration loggingConfiguration = BuildProgrammaticConfig();
            defaultWriter = new LogWriter(loggingConfiguration);
        }

        private LoggingConfiguration BuildProgrammaticConfig()
        {
            LoggingConfiguration loggingConfiguration = new LoggingConfiguration();
            loggingConfiguration.IsLoggingEnabled = false;
            return loggingConfiguration;
        }

        public void Log(string message, LogType logType)
        {
            defaultWriter.Write(new LogEntry() { Message = message });
        }

        public void Log(Exception exception)
        {
          
        }
    }
}
