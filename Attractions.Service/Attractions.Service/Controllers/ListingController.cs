using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Attractions.Processor;
using Attractions.Contracts;
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

        public async Task<IHttpActionResult> GetAsync(int id)
        {
            var content = await this.listingProcessor.GetListingByIdAsync(id);
            if (content == null)
                return NotFound();
            return Ok(content);
        }

        public async Task<IHttpActionResult> PostAsync([FromBody]Listing listing)
        {
            await this.listingProcessor.InsertListingAsync(listing);
            return Created(Request.RequestUri, listing);
        }

        public async Task<IHttpActionResult> PutAsync(int id, [FromBody]Listing listing)
        {
            await this.listingProcessor.UpdateListingAsync(listing);
            return Created(Request.RequestUri,listing);
        }

        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            await this.listingProcessor.DeleteListingAsync(id);
            return Ok(id);
        }
    }
}