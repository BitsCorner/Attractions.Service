using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Attractions.Repository;
using Attractions.Repository.Models;
using System.Threading.Tasks;
namespace Attractions.Service.Controllers
{
    public class ListingController : BaseController
    {
        public async Task<HttpResponseMessage> GetAsync()
        {
            var content = this.unitOfWork.ListingRepository.GetAsync();
            //TODO: add filter for Locale?
            //filter:
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> Get(int id)
        {
            var content = this.unitOfWork.ListingRepository.GetByIDAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody]Listing listing)
        {
            await this.unitOfWork.ListingRepository.InsertAsync(listing);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, listing);
        }

        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody]Listing listing)
        {
            await this.unitOfWork.ListingRepository.UpdateAsync(listing);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, listing);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await this.unitOfWork.ListingRepository.DeleteAsync(id);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}