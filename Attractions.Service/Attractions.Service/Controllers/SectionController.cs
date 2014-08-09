using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Attractions.Repository;
using Attractions.Repository.Models;
namespace Attractions.Service.Controllers
{
    public class SectionController : BaseController
    {
        public IEnumerable<Section> Get()
        {
            return this.unitOfWork.SectionRepository.Get(orderBy: q => q.OrderBy(d => d.SectionName));
            //TODO: add filter for Locale?
            //filter:
        }

        public Section Get(int id)
        {
            return this.unitOfWork.SectionRepository.Get(filter: q => q.SectionId == id).FirstOrDefault();
        }

        public void Post([FromBody]Section Section)
        {
            this.unitOfWork.SectionRepository.Insert(Section);
            this.unitOfWork.Save();
        }

        public void Put(int id, [FromBody]Section Section)
        {
            this.unitOfWork.SectionRepository.Update(Section);
            this.unitOfWork.Save();
        }

        public void Delete(int id)
        {
            this.unitOfWork.SectionRepository.Delete(id);
            this.unitOfWork.Save();
        }
    }
}