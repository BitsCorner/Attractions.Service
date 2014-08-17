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
    public class SectionController : BaseController
    {
        public async Task<HttpResponseMessage> GetAsync()
        {
            var content = await this.unitOfWork.SectionRepository.GetAsync(orderBy: q => q.OrderBy(d => d.SectionName));
            //TODO: add filter for Locale?
            //filter:
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> GetAsync(int id)
        {
            var content = await this.unitOfWork.SectionRepository.GetByIDAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK, content);
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody]Section Section)
        {
            await this.unitOfWork.SectionRepository.InsertAsync(Section);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, Section);
        }

        public async Task<HttpResponseMessage> PutAsync(int id, [FromBody]Section section)
        {
            await this.unitOfWork.SectionRepository.UpdateAsync(section);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, section);
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id)
        {
            await this.unitOfWork.SectionRepository.DeleteAsync(id);
            await this.unitOfWork.SaveAsync();
            return Request.CreateResponse(HttpStatusCode.OK, id);
        }
    }
}