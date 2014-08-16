using Attractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Attractions.Service.Controllers
{
    public class BaseController : ApiController
    {

        protected UnitOfWork unitOfWork = new UnitOfWork();

        public override System.Threading.Tasks.Task<HttpResponseMessage> ExecuteAsync(System.Web.Http.Controllers.HttpControllerContext controllerContext, System.Threading.CancellationToken cancellationToken)
        {
            return base.ExecuteAsync(controllerContext, cancellationToken);

            //todo
        }

    }
}
