using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Attractions.Service.Filters
{
    public class ExceptionFilter : IExceptionFilter 
    {
        public void OnException(ExceptionContext filterContext)
        {
            var loggingConfig = new Microsoft.Practices.EnterpriseLibrary.Logging.LoggingConfiguration();
            var logWriter = new Microsoft.Practices.EnterpriseLibrary.Logging.LogWriter(loggingConfig);
            logWriter.Write(filterContext.Exception);
        }
    }
}
