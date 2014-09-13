using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Attractions.Processor;
using Attractions.Contracts;
using Attractions.Service.Logging;
namespace Attractions.Service.Controllers
{
    public class UsageTypeController : BaseController
    {
        private IListingProcessor listingProcessor;
        
        public UsageTypeController(IListingProcessor _listingProcessor)
        {
            this.listingProcessor = _listingProcessor;
        }

        public async Task<IHttpActionResult> GetAsync()
        {
            var content = await this.listingProcessor.GetUsageTypesAsync();
            return Ok(content);
        }

    }
}