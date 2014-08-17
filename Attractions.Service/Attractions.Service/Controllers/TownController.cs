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
    public class TownController : BaseController
    {
        public async Task<HttpResponseMessage> GetAsync()
        {
            var content = await this.unitOfWork.TownRepository.GetAsync(orderBy: q => q.OrderBy(d => d.TownName));
            //TODO: add filter for Locale?
            //filter:
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> GetAsync(int id)
        {
            var result = await this.unitOfWork.TownRepository.GetAsync(filter: q => q.TownId == id);
            return Request.CreateResponse(HttpStatusCode.OK, result.FirstOrDefault());
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody]Town town)
        {
            await this.unitOfWork.TownRepository.InsertAsync(town);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, town);
        }

        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody]Town town)
        {
            await this.unitOfWork.TownRepository.UpdateAsync(town);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, town);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await this.unitOfWork.TownRepository.DeleteAsync(id);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}