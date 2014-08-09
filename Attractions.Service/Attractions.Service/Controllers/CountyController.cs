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
    public class CountyController : BaseController
    {
        public IEnumerable<Country> Get()
        {
            return this.unitOfWork.CountryRepository.Get(orderBy: q => q.OrderBy(d => d.CountryName));
            //TODO: add filter for Locale?
            //filter:
        }

        public Country Get(int id)
        {
            return this.unitOfWork.CountryRepository.Get(filter: q => q.CountryId == id).FirstOrDefault();
        }

        public void Post([FromBody]Country country)
        {
            this.unitOfWork.CountryRepository.Insert(country);
            this.unitOfWork.Save();
        }

        public void Put(int id, [FromBody]string value)
        {
        }

        public void Delete(int id)
        {
            this.unitOfWork.CountryRepository.Delete(id);
            this.unitOfWork.Save();
        }
    }
}