using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void Log(string message, TraceEventType eventType)
        {
            defaultWriter.Write(new LogEntry() { 
                ActivityId = Guid.NewGuid(), //System.Threading.Thread.CurrentThread.
                Message = message,
                EventId = 0, // TODO: need explicit error/information type code for this 
                Severity  = eventType,
                TimeStamp = DateTime.UtcNow,
                Title = "", // 
                MachineName = "", // this is the Host computer name?
            });
        }

        public void Log(Exception exception)
        {
          
        }
    }
}
