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
    public class StateController : BaseController
    {
        public async Task<HttpResponseMessage> GetAsync()
        {
            var content = await this.unitOfWork.StateRepository.GetAsync(orderBy: q => q.OrderBy(d => d.StateName));
            return Request.CreateResponse(HttpStatusCode.OK, content);
            //TODO: add filter for Locale?
            //filter:
        }

        public async Task<HttpResponseMessage> GetAsync(int id)
        {
            var content = await this.unitOfWork.StateRepository.GetByIDAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody]State state)
        {
            await this.unitOfWork.StateRepository.InsertAsync(state);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, state);
        }

        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody]State state)
        {
            await this.unitOfWork.StateRepository.UpdateAsync(state);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, state);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await this.unitOfWork.StateRepository.DeleteAsync(id);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}