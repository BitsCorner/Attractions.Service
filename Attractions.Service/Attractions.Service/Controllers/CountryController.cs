using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Attractions.Repository;
using Attractions.Repository.Models;
using System.Threading.Tasks;
using BitsCorner.Logging;
using System.Diagnostics;
namespace Attractions.Service.Controllers
{
    public class CountryController : BaseController
    {

        private ILogger logger;
        public CountryController(ILogger logger)
        {
            this.logger = logger;
        }


        public async Task<HttpResponseMessage> GetAsync()
        {
            var countries = await this.unitOfWork.CountryRepository.GetAsync(orderBy: q => q.OrderBy(d => d.CountryName));
            logger.Log("dfsf", TraceEventType.Information);
            //TODO: add filter for Locale?
            //filter:
            return Request.CreateResponse(HttpStatusCode.OK, countries);
        }

        public async Task<HttpResponseMessage> GetAsync(int id)
        {
            var country = await this.unitOfWork.CountryRepository.GetAsync(filter: q => q.CountryId == id);
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody]Country country)
        {
            await this.unitOfWork.CountryRepository.InsertAsync(country);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.Created, country);
        }

        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody]Country country)
        {
            await this.unitOfWork.CountryRepository.UpdateAsync(country);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.Created, country);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await this.unitOfWork.CountryRepository.DeleteAsync(id);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}