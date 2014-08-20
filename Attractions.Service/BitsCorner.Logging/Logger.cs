using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitsCorner.Logging
{
    public class Logger : ILogger
    {
        public Task Log(string message, LogType logType)
        {
            throw new NotImplementedException();
        }

        public Task Log(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}
