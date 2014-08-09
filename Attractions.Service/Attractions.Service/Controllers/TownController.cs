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
    public class TownController : BaseController
    {
        public IEnumerable<Town> Get()
        {
            return this.unitOfWork.TownRepository.Get(orderBy: q => q.OrderBy(d => d.TownName));
            //TODO: add filter for Locale?
            //filter:
        }

        public Town Get(int id)
        {
            return this.unitOfWork.TownRepository.Get(filter: q => q.TownId == id).FirstOrDefault();
        }

        public void Post([FromBody]Town Town)
        {
            this.unitOfWork.TownRepository.Insert(Town);
            this.unitOfWork.Save();
        }

        public void Put(int id, [FromBody]Town Town)
        {
            this.unitOfWork.TownRepository.Update(Town);
            this.unitOfWork.Save();
        }

        public void Delete(int id)
        {
            this.unitOfWork.TownRepository.Delete(id);
            this.unitOfWork.Save();
        }
    }
}