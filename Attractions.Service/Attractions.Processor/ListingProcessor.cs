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
        {
            var result = await unitOfWork.ListingRepository.GetAsync(includeProperties: "Location,Category,Locale,UsageTypes,Status");
            return EntityMapper.Map(result);
        }

        public async Task<Listing> InsertListingAsync(Listing listing)
        {
            var contextListing = EntityMapper.Map(listing);
            await unitOfWork.ListingRepository.InsertAsync(contextListing);
            await unitOfWork.SaveAsync();
            return listing;
        }

        public async Task<Listing> UpdateListingAsync(Listing listing)
        {
            var contextListing = EntityMapper.Map(listing);
            await unitOfWork.ListingRepository.UpdateAsync(contextListing);
            await unitOfWork.SaveAsync();
            return listing;
        }

        public async Task DeleteListingAsync(int id)
        {
            await unitOfWork.ListingRepository.DeleteAsync(id);
        }

        public async Task<Listing> GetListingByIdAsync(int id)
        {
            var ContractListing = await unitOfWork.ListingRepository.GetAsync(filter: m => m.ListingId == id, includeProperties: "Location,Category,Locale,UsageTypes,Status");
            return EntityMapper.Map(ContractListing.FirstOrDefault());
        }

    }
}
