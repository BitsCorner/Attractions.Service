using Attractions.Contracts;
using Attractions.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attractions.Processor
{
    public class ListingProcessor : IListingProcessor
    {
        protected UnitOfWork unitOfWork = new UnitOfWork();
        public ListingProcessor(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Listing>> GetAllListingsAsync()
        {   var result = await unitOfWork.ListingRepository.GetAsync();
            return EntityMapper.Map(result);
        }

        public Task InsertListingAsync(Listing listing)
        {
            throw new NotImplementedException();
        }

        public Task UpdateListingAsync(Listing listing)
        {
            throw new NotImplementedException();
        }

        public Task DeleteListingAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Listing> GetListingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }


    }
}
