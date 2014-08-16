using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Attractions.Service.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(!actionContext.ModelState.IsValid)
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            //if (objectContent != null)
            //{
            //    var type = objectContent.ObjectType; //type of the returned object
            //    var value = objectContent.Value; //holding the returned value
            //}

            ////Debug.WriteLine("ACTION 1 DEBUG  OnActionExecuted Response " + actionExecutedContext.Response.StatusCode.ToString());
        }
    }
}