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
    public class StateController : BaseController
    {
        public IEnumerable<State> Get()
        {
            return this.unitOfWork.StateRepository.Get(orderBy: q => q.OrderBy(d => d.StateName));
            //TODO: add filter for Locale?
            //filter:
        }

        public State Get(int id)
        {
            return this.unitOfWork.StateRepository.Get(filter: q => q.StateId == id).FirstOrDefault();
        }

        public void Post([FromBody]State state)
        {
            this.unitOfWork.StateRepository.Insert(state);
            this.unitOfWork.Save();
        }

        public void Put(int id, [FromBody]State state)
        {
            this.unitOfWork.StateRepository.Update(state);
            this.unitOfWork.Save();
        }

        public void Delete(int id)
        {
            this.unitOfWork.StateRepository.Delete(id);
            this.unitOfWork.Save();
        }
    }
}