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

        public void Log(string title, string message, TraceEventType eventType, int eventId)
        {
                defaultWriter.Write(new LogEntry() { 
                ActivityId = Guid.NewGuid(), //TODO:
                Message = message,
                EventId = eventId, // TODO: 
                Severity  = eventType,
                TimeStamp = DateTime.UtcNow,
                Title = title, 
                MachineName = Environment.MachineName 
            });
        }

        public void Log(Exception exception)
        {
          
        }
    }
}
