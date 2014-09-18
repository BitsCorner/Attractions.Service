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
    public class LocationController : BaseController
    {
        private IListingProcessor listingProcessor;
        
        public LocationController(IListingProcessor _listingProcessor)
        {
            this.listingProcessor = _listingProcessor;
        }

        public async Task<IHttpActionResult> GetAsync()
        {
            var content = await this.listingProcessor.GetAllListingsAsync();
            return Ok(content);
        }

    }
}