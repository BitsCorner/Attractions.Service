using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logging
{
    public interface ILogger
    {
        Task LogException(Exception ex);
        Task LogWarning(string Message);
        Task LogInfo(string Message);
    }
}
