using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public class Logger : ILogger
    {
        public Task LogException(Exception ex)
        {
            throw new NotImplementedException();
        }

        public Task LogWarning(string Message)
        {
            throw new NotImplementedException();
        }

        public Task LogInfo(string Message)
        {
            throw new NotImplementedException();
        }
    }
}
