using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace Attractions.Service.Filters
{
    public class ExceptionFilter : IExceptionFilter
 
    {
        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, System.Threading.CancellationToken cancellationToken)
        {
            var loggingConfig = new Microsoft.Practices.EnterpriseLibrary.Logging.LoggingConfiguration();
            var logWriter = new Microsoft.Practices.EnterpriseLibrary.Logging.LogWriter(loggingConfig);
            logWriter.Write(actionExecutedContext.Exception);
        }

        public bool AllowMultiple
        {
	        get { throw new NotImplementedException(); }
        }
    }
}
