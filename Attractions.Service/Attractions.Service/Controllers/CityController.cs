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
    public class CityController : BaseController
    {
        public IEnumerable<City> Get()
        {
            return this.unitOfWork.CityRepository.Get(orderBy: q => q.OrderBy(d => d.CityName));
            //TODO: add filter for Locale?
            //filter:
        }

        public City Get(int id)
        {
            return this.unitOfWork.CityRepository.Get(filter: q => q.CityId == id).FirstOrDefault();
        }

        public void Post([FromBody]City City)
        {
            this.unitOfWork.CityRepository.Insert(City);
            this.unitOfWork.Save();
        }

        public void Put(int id, [FromBody]City City)
        {
            this.unitOfWork.CityRepository.Update(City);
            this.unitOfWork.Save();
        }

        public void Delete(int id)
        {
            this.unitOfWork.CityRepository.Delete(id);
            this.unitOfWork.Save();
        }
    }
}