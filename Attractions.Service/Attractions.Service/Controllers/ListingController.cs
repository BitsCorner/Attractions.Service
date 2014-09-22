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
using Attractions.Contracts.Requests;
using Attractions.Contracts.Responses;

namespace Attractions.Service.Controllers
{
    public class ListingController : BaseController
    {
        private IListingProcessor listingProcessor;
        
        public ListingController(IListingProcessor _listingProcessor)
        {
            this.listingProcessor = _listingProcessor;
        }

        public async Task<IHttpActionResult> GetAsync()
        {
            var content = await this.listingProcessor.GetAllListingsAsync();
            return Ok(content);
        }

        /// <summary>
        /// This returns a single item based on the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var content = await this.listingProcessor.GetListingByIdAsync(id);
            if (content == null)
                return NotFound();
            return Ok(content);
        }

        public async Task<IHttpActionResult> PostAsync([FromBody]ListingRequest listing)
        {
            var newListing = await this.listingProcessor.InsertListingAsync(listing);
            if (newListing != null)
            {
                return Created<ListingResponse>(Request.RequestUri, newListing);
            }
            else
            {
                return Conflict();
            }
        }

        public async Task<IHttpActionResult> PutAsync(int id, [FromBody]ListingRequest listing)
        {
            //await this.listingProcessor.UpdateListingAsync(listing);
            //return Created(Request.RequestUri,listing);
            return null;
        }

        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            //await this.listingProcessor.DeleteListingAsync(id);
            //return Ok(id);
            return null;
        }
    }
}