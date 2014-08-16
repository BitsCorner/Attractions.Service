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
    public class CityController : BaseController
    {
        public async Task<HttpResponseMessage> GetAsync()
        {
            var content = this.unitOfWork.CityRepository.GetAsync(orderBy: q => q.OrderBy(d => d.CityName));
            return Request.CreateResponse(HttpStatusCode.OK, content);
            //TODO: add filter for Locale?
            //filter:
        }

        public async Task<HttpResponseMessage> GetAsync(int id)
        {
            var content = await this.unitOfWork.CityRepository.GetAsync(filter: q => q.CityId == id);
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody]City city)
        {
            await this.unitOfWork.CityRepository.InsertAsync(city);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, city);
        }

        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody]City city)
        {
            await this.unitOfWork.CityRepository.UpdateAsync(city);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, city);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await this.unitOfWork.CityRepository.DeleteAsync(id);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}