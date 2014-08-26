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
        public async Task<HttpResponseMessage> GetAsync()
        {
            var content = await this.listingProcessor.GetAllListingsAsync();
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> GetAsync(int id)
        {
            var content = await this.listingProcessor.GetListingByIdAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody]Listing listing)
        {
            await this.listingProcessor.InsertListingAsync(listing);
            return Request.CreateResponse(HttpStatusCode.OK, listing);
        }

        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody]Listing listing)
        {
            await this.listingProcessor.UpdateListingAsync(listing);
            return Request.CreateResponse(HttpStatusCode.OK, listing);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await this.listingProcessor.DeleteListingAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}