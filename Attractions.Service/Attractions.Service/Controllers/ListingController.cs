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
    public class ListingController : BaseController
    {
        public IEnumerable<Listing> Get()
        {
            return this.unitOfWork.ListingRepository.Get();
            //TODO: add filter for Locale?
            //filter:
        }

        public Listing Get(int id)
        {
            return this.unitOfWork.ListingRepository.Get(filter: q => q.ListingId == id).FirstOrDefault();
        }

        public void Post([FromBody]Listing Listing)
        {
            this.unitOfWork.ListingRepository.Insert(Listing);
            this.unitOfWork.Save();
        }

        public void Put(int id, [FromBody]Listing Listing)
        {
            this.unitOfWork.ListingRepository.Update(Listing);
            this.unitOfWork.Save();
        }

        public void Delete(int id)
        {
            this.unitOfWork.ListingRepository.Delete(id);
            this.unitOfWork.Save();
        }
    }
}